# AI Playground (DeepSeek and WPF)

**AI Playground (DeepSeek and WPF)** is a simple WPF application that integrates DeepSeek both in code and via a WebUI.

## 🚀 Installation Guide

### 🛠 Prerequisites

- Kubernetes cluster (e.g., [k3s / Rancher](https://github.com/rancher-sandbox/rancher-desktop), MiniKube, or managed service) 
- [Helm](https://github.com/helm/helm) installed (`v3+`)

## 📦 Step-by-Step Installation

### 1. Add Required Helm Repositories

```bash
helm repo add open-webui https://helm.openwebui.com/
helm repo add ollama-helm https://otwld.github.io/ollama-helm/
helm repo update
```

The WebUI will be available at http://open-webui.localhost

### 2. Install WebUI and Ollama

This will install the charts with preconfigured values, like used LLMs, browser pathes and ports.

```bash
# install WebUI with DeepSeek and llama3
helm upgrade --install open-webui open-webui/open-webui \
  --version 6.4.0 \
  -f "./infrastructure/charts/open-webui/values.yaml" \
  --wait

# install a standalone version of DeepSeek
helm upgrade --install ollama ollama-helm/ollama \
  --version 1.15.0 \
  -f "./infrastructure/charts/ollama/values.yaml" \
  --wait
```

### 3. 🔒 Create a Self-Signed SSL Certificate

Run the provided script to:

- Generate a self-signed certificate
- Deploy it as a Kubernetes secret for NGINX reverse proxy

```powershell
.\infrastructure\create-ssl-certificate\create-and-apply-certificate.cmd
```

You must manually install the certificate in your system's **Trusted Root Certification Authorities** to avoid browser warnings.



## 📂 Project Structure

```bash
infrastructure/
├── charts/
│   ├── open-webui/
│   │   └── values.yaml
│   └── ollama/
│       └── values.yaml
└── create-ssl-certificate/
    └── create-and-apply-certificate.cmd
```
