# Docker Images #

The following docker images have been verified to successfully build the source-build repo.

| OS | Image |
| --- | --- |
| CentOS 7.1 | microsoft/dotnet-buildtools-prereqs:centos-7-b46d863-20180719033416 |
| Fedora 28 | microsoft/dotnet-buildtools-prereqs:fedora-28-c103199-20180628122443 |
| Ubuntu 16.04 | microsoft/dotnet-buildtools-prereqs:ubuntu-16.04-c103199-20180628134544 |

## Building source-build with Docker ##

```
> ### Create a volume on which to build source-build
> docker volume create source-build-volume 

> ### Clone source-build repo
> docker run -it --rm --mount source=source-build-test,target=/src -w /src <imageName> /bin/bash -c "git clone https://github.com/dotnet/source-build"

> ### Build source-build to create a tarball
> docker run -it --rm --mount source=source-build-test,target=/src -w /src/source-build <imageName> /bin/bash -c "./build-source-tarball.sh ../tarball"

> ### Build the tarball
> docker run -it --rm --mount source=source-build-test,target=/src -w /src/tarball <imageName> /bin/bash -c "./build.sh"
```