#!/usr/bin/env bash

# Stop script if unbound variable found (use ${var:-} if intentional)
set -u

# Stop script if command returns non-zero exit code.
# Prevents hidden errors caused by missing error code propagation.
set -e

usage()
{
	cat << _EOF
Common settings:
  --configuration <value>    Build configuration: 'Debug' or 'Release' (short: -c)
  --verbosity <value>        Msbuild verbosity: q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic] (short: -v)
  --binaryLog                Create MSBuild binary log (short: -bl)
  --help                     Print help and exit (short: -h)

Actions:
  --restore                  Restore dependencies (short: -r)
  --build                    Build solution (short: -b)
  --rebuild                  Rebuild solution
  --test                     Run all unit tests in the solution (short: -t)
  --integrationTest          Run all integration tests in the solution
  --performanceTest          Run all performance tests in the solution
  --pack                     Package build outputs into NuGet packages and Willow components
  --sign                     Sign build outputs
  --publish                  Publish artifacts (e.g. symbols)
  --clean                    Clean the solution

Advanced settings:
  --projects <value>       Project or solution file(s) to build
  --ci                     Set when running on CI server
  --excludeCIBinarylog     Don't output binary log (short: -nobl)
  --prepareMachine         Prepare machine for CI run, clean up processes after build
  --nodeReuse <value>      Sets nodereuse msbuild parameter ('true' or 'false')
  --warnAsError <value>    Sets warnaserror msbuild parameter ('true' or 'false')

Command line arguments not listed above are passed thru to msbuild.
Arguments can also be passed in with a single hyphen.
_EOF
}

source="${BASH_SOURCE[0]}"

# resolve $source until the file is no longer a symlink
while [[ -h "$source" ]]; do
  scriptroot="$( cd -P "$( dirname "$source" )" && pwd )"
  source="$(readlink "$source")"
  # if $source was a relative symlink, we need to resolve it relative to the path where the
  # symlink file was located
  [[ $source != /* ]] && source="$scriptroot/$source"
done
scriptroot="$( cd -P "$( dirname "$source" )" && pwd )"

restore=false
build=false
rebuild=false
test=false
integration_test=false
performance_test=false
pack=false
publish=false
sign=false
public=false
ci=false
clean=false

warn_as_error=true
node_reuse=true
binary_log=false
exclude_ci_binary_log=false
pipelines_log=false

projects=''
configuration='Debug'
prepare_machine=false
verbosity='minimal'
runtime_source_feed=''
runtime_source_feed_key=''

properties=''
while [[ $# > 0 ]]; do
  opt="$(echo "${1/#--/-}" | tr "[:upper:]" "[:lower:]")"
  case "$opt" in
    -help|-h)
      usage
      exit 0
      ;;
    -clean)
      clean=true
      ;;
    -configuration|-c)
      configuration=$2
      shift
      ;;
    -verbosity|-v)
      verbosity=$2
      shift
      ;;
    -binarylog|-bl)
      binary_log=true
      ;;
    -excludeCIBinarylog|-nobl)
      exclude_ci_binary_log=true
      ;;
    -pipelineslog|-pl)
      pipelines_log=true
      ;;
    -restore|-r)
      restore=true
      ;;
    -build|-b)
      build=true
      ;;
    -rebuild)
      rebuild=true
      ;;
    -pack)
      pack=true
      ;;
    -test|-t)
      test=true
      ;;
    -integrationtest)
      integration_test=true
      ;;
    -performancetest)
      performance_test=true
      ;;
    -sign)
      sign=true
      ;;
    -publish)
      publish=true
      ;;
    -preparemachine)
      prepare_machine=true
      ;;
    -projects)
      projects=$2
      shift
      ;;
    -ci)
      ci=true
      ;;
    -warnaserror)
      warn_as_error=$2
      shift
      ;;
    -nodereuse)
      node_reuse=$2
      shift
      ;;
    -runtimesourcefeed)
      runtime_source_feed=$2
      shift
      ;;
     -runtimesourcefeedkey)
      runtime_source_feed_key=$2
      shift
      ;;
    *)
      properties="$properties $1"
      ;;
  esac

  shift
done

if [[ "$ci" == true ]]; then
  pipelines_log=true
  node_reuse=false
  if [[ "$exclude_ci_binary_log" == false ]]; then
    binary_log=true
  fi
fi

. "$scriptroot/tools.sh"

function InitializeCustomToolset {
  local script="$eng_root/restore-toolset.sh"

  if [[ -a "$script" ]]; then
    . "$script"
  fi
}

function Build {
  InitializeToolset
  InitializeCustomToolset

  if [[ ! -z "$projects" ]]; then
    properties="$properties /p:Projects=$projects"
  fi

  local bl=""
  if [[ "$binary_log" == true ]]; then
    bl="/bl:\"$log_dir/Build.binlog\""
  fi

  MSBuild $_InitializeToolset \
    $bl \
    /p:Configuration=$configuration \
    /p:RepoRoot="$repo_root" \
    /p:Restore=$restore \
    /p:Build=$build \
    /p:Rebuild=$rebuild \
    /p:Test=$test \
    /p:Pack=$pack \
    /p:IntegrationTest=$integration_test \
    /p:PerformanceTest=$performance_test \
    /p:Sign=$sign \
    /p:Publish=$publish \
    $properties

  ExitWithExitCode 0
}

if [[ "$clean" == true ]]; then
  if [ -d "$artifacts_dir" ]; then
    rm -rf $artifacts_dir
    echo "Artifacts directory deleted."
  fi
  exit 0
fi

if [[ "$restore" == true ]]; then
  InitializeNativeTools
fi

Build
