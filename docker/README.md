# Docker Images #

The following docker images have been verified to successfully build the source-build repo by:

1. Building source-build
2. Building the resulting tarball
3. Running smoke tests

| OS | Image Name | Link to Dockerfile | Verification Date |
| --- | --- | --- | --- |
| CentOS 7.1 | microsoft/dotnet-buildtools-prereqs:centos-7-b46d863-20180719033416 | [CentOS 7.1](https://github.com/dotnet/dotnet-buildtools-prereqs-docker/blob/master/src/centos/7/Dockerfile) | 2018.09.05 |
| Fedora 28 | microsoft/dotnet-buildtools-prereqs:fedora-28-c103199-20180628122443 | [Fedora 28](https://github.com/dotnet/dotnet-buildtools-prereqs-docker/blob/master/src/fedora/28/Dockerfile) | 2018.09.05 |
| Ubuntu 16.04 | microsoft/dotnet-buildtools-prereqs:ubuntu-16.04-c103199-20180628134544 |[Ubuntu 16.04](https://github.com/dotnet/dotnet-buildtools-prereqs-docker/blob/master/src/ubuntu/16.04/Dockerfile) | 2018.09.05 |

## Building source-build with Docker ##

### Running an interactive docker container
```
### Run a bash shell inside a docker container. All later steps run in the interactive shell.
docker run -it --rm <imageName> /bin/bash

### Clone source-build repo
git clone https://github.com/dotnet/source-build
cd source-build

### Build source-build to create a tarball
./build-source-tarball.sh ../tarball

### Build the tarball
cd ../tarball
./build.sh

### Run smoke tests
./smoke-test.sh

### Clean up the container when you're done working with the build results
exit
```

### Running build commands in a docker container with a docker volume for a working directory.  A docker volume allows you to persist data across docker container instances.
```
### Create a volume on which to build source-build
docker volume create source-build-volume 

### Clone source-build repo
docker run --rm --mount source=source-build-volume,target=/src -w /src <imageName> /bin/bash -c "git clone https://github.com/dotnet/source-build"

### Build source-build to create a tarball
docker run --rm --mount source=source-build-volume,target=/src -w /src/source-build <imageName> /bin/bash -c "./build-source-tarball.sh ../tarball"

### Build the tarball
docker run --rm --mount source=source-build-volume,target=/src -w /src/tarball <imageName> /bin/bash -c "./build.sh"

### Run smoke tests
docker run --rm --mount source=source-build-volume,target=/src -w /src/tarball <imageName> /bin/bash -c "./smoke-test.sh"

### Run an interactive container with the docker volume
docker run -it --rm --mount source-build-volume,target=/src -w /src <imageName> /bin/bash

### Remove a volume when finished with it
docker volume rm source-build-volume
```