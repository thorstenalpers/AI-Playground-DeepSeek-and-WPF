@echo off


helm repo add open-webui https://helm.openwebui.com/
helm repo add ollama-helm https://otwld.github.io/ollama-helm/

helm repo update

helm upgrade --install open-webui --version 5.1.1 open-webui/open-webui -f ".\charts\open-webui\values.yaml" --wait
helm upgrade --install ollama ollama-helm/ollama --version 1.4.1 -f ".\charts\ollama\values.yaml" --wait

REM helm show values superset/superset --version 0.12.11 > values.yaml
REM helm show values ollama-helm/ollama --version 1.4.1  > values.yaml