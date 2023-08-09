# stage 1
FROM node:18.10.0 as node
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build

# stage 2
FROM nginx:alpine
COPY nginx.conf /etc/nginx/nginx.conf
COPY security-headers.conf /etc/nginx/security-headers.conf
COPY --from=node /app/dist/horas-extras-web /usr/share/nginx/html
EXPOSE 80