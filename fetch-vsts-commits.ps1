param (
    [Parameter(Mandatory=$true)][string]$pat,
    [string]$remote_ref_name = "vsts"
)

function get_vsts_url(
    [Parameter(Mandatory=$true)][string]$name,
    [string]$instance = 'devdiv.visualstudio.com',
    [string]$project = 'DevDiv')
{
    return "https://usernameplaceholder:${pat}@${instance}/${project}/_git/${name}/"
}

function fetch(
    [Parameter(Mandatory=$true)][string]$name,
    [Parameter(Mandatory=$true)][string]$remote)
{
    $cmd = @(
        "-C", "src/$name"
        # Disable credential manager if one is specified. Always use manual PAT.
        "-c", "credential.helper="
        "fetch"
        $remote
        "+refs/heads/*:refs/remotes/${remote_ref_name}/*"
    )
    echo "Fetching commits using: & git $cmd"
    & git @cmd
}

function fetch_vsts(
    [Parameter(Mandatory=$true)][string]$name,
    [string]$url = (get_vsts_url "DotNet-$name-Trusted"))
{
    fetch "$name" "$url"
}

fetch_vsts cli
fetch_vsts core-setup
fetch_vsts coreclr
fetch_vsts corefx
