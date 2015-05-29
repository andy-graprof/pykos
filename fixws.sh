#!/bin/bash

files=$(find . -type f -not -path '*/\.*' -name '*.cs' -or -name '*.c' -or -name '*.h' -or -name '*.py')

for file in $files; do
  echo "fixing whitespace errors in '$file'"
  sed -i -e 's/[[:space:]]*$//' $file
done

echo "all done. review changes before committing!"
