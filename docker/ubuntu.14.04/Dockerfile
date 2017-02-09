FROM ubuntu:14.04

RUN apt-get update && \
    apt-get upgrade -qqy && \
    apt-get install -qqy curl \
        unzip \
        git \
        python \
        build-essential \
        cmake \
        automake \
        libtool \
        clang-3.5 \
        lldb-3.6-dev \
        libunwind8-dev \
        libicu-dev \
        liblttng-ust-dev \
        libcurl4-openssl-dev \
        libssl-dev \
        uuid-dev \
        gettext && \
    locale-gen en_US.UTF-8 && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/* /tmp/* /var/tmp/*

ENV LANG=en_US.UTF-8 LANGUAGE=en_US:en LC_ALL=en_US.UTF-8
