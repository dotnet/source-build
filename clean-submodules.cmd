@echo off
git submodule foreach --recursive git clean -dxf
git submodule foreach --recursive git reset --hard