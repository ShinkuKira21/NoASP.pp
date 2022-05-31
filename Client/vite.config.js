import { defineConfig } from 'vite'

export default defineConfig({
    server: {
        https: true,
        host: '0.0.0.0',
        port: 443
      }
});
