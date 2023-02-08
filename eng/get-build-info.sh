#!/bin/bash

az config set extension.use_dynamic_install=yes_without_prompt

function get_build_run () {
    local pipeline_id="$1"
    local pipeline_name="$2"
    local azdo_org="$3"
    local azdo_project="$4"
    local tag="$5"

    if [[ -n "$tag" ]]; then
        build_runs=$(az pipelines runs list --organization "$azdo_org" --project "$azdo_project" --pipeline-ids "$pipeline_id" --tags "$tag")
    else
        build_runs=$(az pipelines runs list --organization "$azdo_org" --project "$azdo_project" --pipeline-ids "$pipeline_id")
    fi

    runs=$(echo "$build_runs" | jq -r '[.[] | { "result": .result, "id": .id, "sourceVersion": .sourceVersion }]')
    run_count=$(echo "$runs" | jq 'length')

    if [ "$run_count" != "1" ]; then
        local tagged=''
        if [[ -n "$tag" ]]; then
            tagged=" tagged ${tag}"
        fi
        echo "##vso[task.logissue type=error]There are ${run_count} runs of ${pipeline_name}${tagged}. Please manually specify run ID to use."
        echo "##vso[task.logissue type=error]Run IDs are: ${runs}"
        exit 1
    fi

    run_id=$(echo "$runs" | jq -r '.[0].id')
    run_source_version=$(echo "$runs" | jq -r '.[0].sourceVersion')

    # run_result=$(echo "$runs" | jq -r '.[0].result')
    # if [[ "$run_result" == "failed" ]]; then
    #     echo "##vso[task.logissue type=error]: ${pipeline_name} run ID ${run_id} failed. Please manually specify a build ID to use instead. Exiting..."
    #     exit 1
    # fi

    echo "${run_id} ${run_source_version}"
}

function print_build_info() {
    local pipeline_name="$1"
    local pipeline_variable_name="$2"
    local run_id="$3"
    local source_version="$4"

    echo "${pipeline_name} run ID: ${run_id}"
    echo "  Link: https://dev.azure.com/dnceng/internal/_build/results?buildId=${run_id}"
    echo "  Run revision: ${source_version}"
    echo "                https://dev.azure.com/dnceng/internal/_git/${pipeline_name}/commit/${source_version}"
    echo "##vso[task.setvariable variable=${pipeline_variable_name}]${run_id}"
}

function get_build_info () {
    local azdo_org="$1"
    local azdo_project="$2"
    local pipeline_id="$3"
    local pipeline_name="$4"
    local pipeline_variable_name="$5"
    local tag="$6"

    IFS=' '
    run_info=$(get_build_run "$pipeline_id" "$pipeline_name" "$azdo_org" "$azdo_project" "$tag")
    if [[ $? != "0" ]]; then
        echo "$run_info"
        exit 1
    fi

    read -r run_id source_version<<<"$run_info"
    print_build_info "$pipeline_name" "$pipeline_variable_name" "$run_id" "$source_version"
}
