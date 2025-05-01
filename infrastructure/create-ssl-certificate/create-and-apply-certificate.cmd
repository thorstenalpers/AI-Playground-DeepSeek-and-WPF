

openssl req -newkey rsa:2048 -x509 -nodes -keyout server.key -new -out server.crt -subj /CN=localhost -sha256 -config cert.conf -days 3650
	
	
kubectl delete secret localhost-deepseek-secret & kubectl create secret tls localhost-deepseek-secret --key server.key --cert server.crt

set /p DUMMY=Hit ENTER to continue...