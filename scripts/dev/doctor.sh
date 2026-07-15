#!/bin/bash

echo "======================================"
echo " DevOps Playground Doctor"
echo "======================================"
echo

check() {

    NAME=$1
    COMMAND=$2
    VERSION_COMMAND=$3

    if command -v "$COMMAND" >/dev/null 2>&1
    then
        VERSION=$($VERSION_COMMAND | head -n 1)
        printf "✔ %-12s %s\n" "$NAME" "$VERSION"
    else
        printf "✘ %-12s Não instalado\n" "$NAME"
    fi
}

check "Git" git "git --version"
check "Docker" docker "docker --version"
check "Kubectl" kubectl "kubectl version --client"
check "Helm" helm "helm version --short"
check "Kind" kind "kind --version"
check ".NET SDK" dotnet "dotnet --version"

echo
echo "Diagnóstico concluído."
