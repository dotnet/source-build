#!/usr/bin/bash

apt-get install qemu qemu-user-static binfmt-support debootstrap libxml2-utils docker binutils-arm-linux-gnueabihf
./cross/build-rootfs.sh armel tizen

