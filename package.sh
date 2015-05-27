#!/bin/bash

set -u
set -e

VERSION="0.1"
PACKAGE="pykos"

DIR="${PACKAGE}-${VERSION}"
TAR="${DIR}.tar.gz"

PLUGINDIR="${DIR}/Plugins"
LIBSDIR="${DIR}/pykos/libs"
PYAPIDIR="${DIR}/pykos/api"
RESOURCESDIR="${DIR}/Resources"

rm -rf $DIR
mkdir -vp $PLUGINDIR $LIBSDIR $PYAPIDIR $RESOURCESDIR

PLUGIN="PykosLauncher/bin/Debug/PykosLauncher.dll"
LIBS="Pykos/bin/Debug/PyKOS.dll libsteelpython_c/bin/Debug/libsteelpython_c.so"
PYAPI="pykosapi_py/pykos"
RESOURCES="Resources/pykos"

cp -v $PLUGIN $PLUGINDIR
cp -v $LIBS $LIBSDIR
cp -Rv $PYAPI $PYAPIDIR
cp -Rv $RESOURCES $RESOURCESDIR

find $PYAPIDIR -iname '*.pyc' -delete

tar -cvzf $TAR $DIR
rm -rf $DIR
