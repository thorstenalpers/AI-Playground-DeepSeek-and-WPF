# DeepSeek.WPF

**DeepSeek.WPF** is a self-hosted AI assistant powered by [Open WebUI](https://github.com/open-webui/open-webui) and [Ollama](https://github.com/jmorganca/ollama), deployed via Helm on Kubernetes.

---

## 🚀 Installation Guide

### 🛠 Prerequisites

- Kubernetes cluster (e.g., Minikube, k3s, or managed service)
- Helm installed (`v3+`)
- PowerShell (for Windows users running scripts)
- Admin privileges (to install SSL certs)

---

## 📦 Step-by-Step Installation

### 1. Add Required Helm Repositories

```bash
helm repo add open-webui https://helm.openwebui.com/
helm repo add ollama-helm https://otwld.github.io/ollama-helm/
helm repo update
```

### 2. Install with Preconfigured Values

Make sure the values files exist in your project directory (`./infrastructure/charts/...`):

```bash
helm upgrade --install open-webui open-webui/open-webui \
  --version 6.4.0 \
  -f "./infrastructure/charts/open-webui/values.yaml" \
  --wait

helm upgrade --install ollama ollama-helm/ollama \
  --version 1.15.0 \
  -f "./infrastructure/charts/ollama/values.yaml" \
  --wait
```

---

### 3. (Optional) Generate New `values.yaml` Files

Use this if you want to customize Helm chart values:

```bash
helm show values open-webui/open-webui --version 6.4.0 > ./infrastructure/charts/open-webui/values.yaml
helm show values ollama-helm/ollama --version 1.15.0 > ./infrastructure/charts/ollama/values.yaml
```

---

### 4. 🔒 Create a Self-Signed SSL Certificate

Run the provided script to:

- Generate a self-signed certificate
- Deploy it as a Kubernetes secret for NGINX reverse proxy

```powershell
.\infrastructure\create-ssl-certificate\create-and-apply-certificate.cmd
```

🧠 **Note**: You must manually install the certificate in your system's **Trusted Root Certification Authorities** to avoid browser warnings.

---

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

---

## 🤝 Contributing

Pull requests and issues are welcome. Please follow conventional commit guidelines and open issues for significant feature proposals.

---

## 📄 License

MIT License — see `LICENSE` file for details.
