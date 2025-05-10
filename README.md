# AI Playground (WPF)

**AI Playground (WPF)** is a simple WPF application that integrates AI tools via Docker and Kubernetes.

## 📦 Installation Guide

### Prerequisites

- Kubernetes cluster (e.g., [k3s / Rancher](https://github.com/rancher-sandbox/rancher-desktop), MiniKube, or managed service) 
- [Helm](https://github.com/helm/helm) installed (`v3+`)

## Step-by-Step Installation

### 1. Add Required Helm Repositories

```bash
helm repo add open-webui https://helm.openwebui.com/
helm repo add ollama-helm https://otwld.github.io/ollama-helm/
helm repo update
```

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

# install a permanent port-forwarding using a nodeport 
helm upgrade --install ingress-nodeports 
  "./infrastructure/charts/ingress-nodeports/" \
  --wait
```
### 🚀 Run the Application

Build the project in Visual Studio (Ctrl+Shift+B).

Go to bin\Release\netX.X-windows\ or Debug\ and run the .exe.


### 🚀 Great AI Projects

| Project | Description | ⭐ Stars (Approx.) |
|--------|-------------|------------------|
| [AUTOMATIC1111/stable-diffusion-webui](https://github.com/AUTOMATIC1111/stable-diffusion-webui) | A powerful, extensible web UI for Stable Diffusion with support for inpainting, LoRA, ControlNet, and more. | ⭐ 90k+ |
| [comfyanonymous/ComfyUI](https://github.com/comfyanonymous/ComfyUI) | Modular, node-based UI for building advanced Stable Diffusion workflows visually. Great for pros and automation. | ⭐ 58k+ |
| [Significant-Gravitas/AutoGPT](https://github.com/Significant-Gravitas/AutoGPT) | Autonomous GPT-4-based agent that can plan and execute tasks on its own using memory, tools, and feedback loops. | ⭐ 155k+ |
| [nomic-ai/gpt4all](https://github.com/nomic-ai/gpt4all) | Locally running chatbots using fine-tuned LLMs. Easy to run on CPU with an intuitive desktop UI. | ⭐ 44k+ |
| [mudler/LocalAI](https://github.com/mudler/LocalAI) | Open-source alternative to OpenAI APIs, runs LLMs and audio models locally via Docker or binaries. | ⭐ 14k+ |
| [Hugging Face Spaces](https://huggingface.co/spaces) | A hub for interactive demos using ML models. Browse and run community-contributed AI apps in the browser. |  |
| [ollama/ollama](https://github.com/ollama/ollama) | Run and manage large language models like LLaMA and Mistral locally with simple CLI and Docker support. | ⭐ 67k+ |
| [open-webui/open-webui](https://github.com/open-webui/open-webui) | A modern, full-featured web UI for local LLMs like Ollama, supporting chat history, multiple users, and more. | ⭐ 12k+ |
