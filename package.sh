
#!/bin/bash

VERSION="0.1"
PACKAGE="pykos"

DIR="${PACKAGE}-${VERSION}"
TAR="${DIR}.tar.gz"

PLUGINDIR="${DIR}/Plugins"
LIBSDIR="${DIR}/pykos/libs"
RESOURCESDIR="${DIR}/pykos/resources"

rm -rf $DIR
mkdir -vp $PLUGINDIR $LIBSDIR $RESOURCESDIR

PLUGIN="PykosLauncher/bin/Debug/PykosLauncher.dll"
LIBS="Pykos/bin/Debug/PyKOS.dll libsteelpython_c/bin/Debug/libsteelpython_c.so"
RESOURCES="resources/pykos/textures"

cp -v $PLUGIN $PLUGINDIR
cp -v $LIBS $LIBSDIR
cp -Rv $RESOURCES $RESOURCESDIR

tar -cvzf $TAR $DIR
rm -rf $DIR
