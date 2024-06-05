# İmajı tanımla
FROM node:latest AS build

# Çalışma dizinini belirle
WORKDIR /webui

# Package dosyalarını kopyala
COPY "source/repos/TestCenterProject/webui/package*.json" ./

# NPM paketlerini yükle
RUN npm install

# Proje dosyalarını kopyala
COPY "source/repos/TestCenterProject/webui/." ./

# Projeyi derle
RUN npm run build

# Portu aç
EXPOSE 4200

# Uygulamayı başlat
CMD ["npm", "start"]
