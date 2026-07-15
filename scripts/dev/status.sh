#!/bin/bash

echo "===== DevOps Playground ====="

echo ""
echo "Usuário:"
whoami

echo ""
echo "Diretório:"
pwd

echo ""
echo "Docker:"
docker --version

echo ""
echo "Kubectl:"
kubectl version --client

echo ""
echo "Helm:"
helm version --short
