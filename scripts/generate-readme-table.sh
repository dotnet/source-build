#!/usr/bin/env bash
set -euo pipefail

script_root="$(cd -P "$( dirname "$0" )" && pwd)"

branch=master

branch_jenkins=$(printf "$branch" | sed 's/\//_/')
branch_azdo=$branch

readme="$script_root/../README.md"

if [ ! -f "$readme" ]; then
  echo "$readme must exist."
  exit 1
fi

print_rows() {
  echo '| OS | *Jenkins*<br/>Release | <br/>Debug | *Azure DevOps*<br/>Release |'
  echo '| -- | :-- | :-- | :-- |'
  row 'CentOS7.1' 'Production'; jenkins; azdo; end
  row 'CentOS7.1' 'Online'; jenkins; azdo; end
  row 'CentOS7.1' 'Online Portable'; jenkins; end
  row 'CentOS7.1' 'Offline'; none; none; azdo; end
  row 'CentOS7.1' 'Offline Portable'; none; none; azdo; end
  row 'Debian8.2' 'Production'; none; none; azdo; end
  row 'Debian8.2' 'Online'; none; none; azdo; end
  row 'Debian8.4' 'Production'; jenkins; end
  row 'Fedora24' 'Production'; jenkins; end
  row 'Fedora29' 'Production'; none; none; azdo; end
  row 'Fedora29' 'Online'; none; none; azdo; end
  row 'Fedora29' 'Offline'; none; none; azdo; end
  row 'Fedora29' 'Offline Portable'; none; none; azdo; end
  row 'OSX10.12' 'Production'; jenkins; azdo; end
  row 'RHEL7.2' 'Production'; jenkins; end
  row 'RHEL7.2' 'Online'; jenkins; end
  row 'RHEL7.2' 'Online Portable'; jenkins; end
  row 'RHEL7.2' 'Offline'; jenkins; end
  row 'RHEL7.2' 'Offline Portable'; jenkins; end
  row 'Ubuntu16.04' 'Production'; jenkins; azdo; end
  row 'Windows' 'Production'; jenkins; end
}

raw_print() {
  printf '%s' "$1"
}

row() {
  os=$1
  job_type=$2
  display_name=$os
  if [ "$job_type" != "Production" ]; then
    display_name="$display_name ($job_type)"
  fi
  printf "| $display_name | "
}

end() {
  printf '\n'
}

jenkins() {
  job=$os
  tarball_type=
  portability=

  case $job in
    Windows)
      job="Windows_NT"
      ;;
  esac

  case $job_type in
    *Online*)
      tarball_type="_Tarball"
      ;;
    *Offline*)
      tarball_type="_Unshared"
      ;;
  esac

  case $job_type in
    *Portable*)
      portability="_Portable"
  esac

  for configuration in _Release _Debug; do
    j=$job$tarball_type$configuration$portability
    raw_print "[![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/$branch_jenkins/$j)]"
    raw_print "(https://ci.dot.net/job/dotnet_source-build/job/$branch_jenkins/job/$j/) | "
  done
}

azdo() {
  job=$(raw_print $os | awk '{print tolower($0)}' | sed 's/\.//g')

  case $os in
    OSX10.12)
      job=OSX
      ;;
  esac

  job_type_escaped=$(raw_print "$job_type" | sed 's/ /%20/g')
  query="?branchName=$branch_azdo&jobname=$job&configuration=$job_type_escaped"

  raw_print "[![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI$query)]"
  raw_print "(https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=$branch_azdo) | "
}

none() {
  raw_print '| '
}

cp "$readme" "$readme.old"

phase=before
while read line; do
  if [ "$phase" = before ]; then
    echo "$line"
    if [ "$line" = '<!-- Generated table start -->' ]; then
      print_rows
      phase=skip
    fi
  elif [ "$phase" = skip ]; then
    if [ "$line" = '<!-- Generated table end -->' ]; then
      echo "$line"
      phase=after
    fi
  else
    echo "$line"
  fi
done < "$readme.old" > "$readme"

rm "$readme.old"
