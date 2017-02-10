FROM centos:7

RUN curl -L -o /etc/yum.repos.d/EfficiOS-RHEL7-x86-64.repo https://packages.efficios.com/repo.files/EfficiOS-RHEL7-x86-64.repo && \
    yum update -y && \
    yum install -y git \
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
        https://matell.blob.core.windows.net/rpms/clang-3.6.2-1.el7.centos.x86_64.rpm \
        https://matell.blob.core.windows.net/rpms/clang-libs-3.6.2-1.el7.centos.x86_64.rpm \
        https://matell.blob.core.windows.net/rpms/lldb-3.6.2-1.el7.centos.x86_64.rpm \
        https://matell.blob.core.windows.net/rpms/lldb-devel-3.6.2-1.el7.centos.x86_64.rpm \
        https://matell.blob.core.windows.net/rpms/llvm-3.6.2-1.el7.centos.x86_64.rpm \
        https://matell.blob.core.windows.net/rpms/llvm-libs-3.6.2-1.el7.centos.x86_64.rpm && \
    yum clean all && \
    rm -rf /tmp/* /var/tmp/*

ENV LANG=en_US.UTF-8 LANGUAGE=en_US:en LC_ALL=en_US.UTF-8
