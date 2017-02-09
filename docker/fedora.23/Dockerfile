FROM fedora:23

RUN dnf update -y && \
    dnf install -y git \
        python \
        hostname \
        libunwind-devel \
        gettext \
        libuuid-devel \
        lttng-ust-devel \
        libcurl-devel \
        openssl-devel \
        zlib-devel \
        libicu-devel \
        cmake \
        make \
        automake \
        libtool \
        which \
        clang \
        lldb-devel && \
    dnf clean all && \
    rm -rf /tmp/* /var/tmp/*

ENV LANG=en_US.UTF-8 LANGUAGE=en_US:en LC_ALL=en_US.UTF-8
