@echo off
git submodule foreach git clean -dxf
git submodule foreach git reset --hard