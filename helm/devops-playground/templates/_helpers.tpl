{{/*
Nome da aplicação
*/}}
{{- define "devops-playground.name" -}}
{{ .Chart.Name }}
{{- end }}

{{/*
Namespace
*/}}
{{- define "devops-playground.namespace" -}}
{{ .Values.namespace.name }}
{{- end }}

{{/*
Nome completo
*/}}
{{- define "devops-playground.fullname" -}}
{{ printf "%s" .Chart.Name }}
{{- end }}

{{/*
Labels comuns
*/}}
{{- define "devops-playground.labels" -}}
app.kubernetes.io/name: {{ include "devops-playground.name" . }}
app.kubernetes.io/instance: {{ .Release.Name }}
app.kubernetes.io/managed-by: {{ .Release.Service }}
helm.sh/chart: {{ .Chart.Name }}-{{ .Chart.Version }}
{{- end }}

{{/*
API Label
*/}}
{{- define "devops-playground.apiLabel" -}}
devops-api
{{- end }}

{{/*
Postgres Label
*/}}
{{- define "devops-playground.postgresLabel" -}}
postgres
{{- end }}