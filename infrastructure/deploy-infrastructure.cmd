@echo off


helm repo add open-webui https://helm.openwebui.com/
helm repo add ollama-helm https://otwld.github.io/ollama-helm/

helm repo update

helm upgrade --install open-webui --version 6.4.0 open-webui/open-webui -f ".\charts\open-webui\values.yaml" --wait
helm upgrade --install ollama ollama-helm/ollama --version 1.15.0 -f ".\charts\ollama\values.yaml" --wait

REM helm show values open-webui/open-webui --version 6.4.0 > values.yaml
REM helm show values ollama-helm/ollama --version 1.15.0 > values.yaml