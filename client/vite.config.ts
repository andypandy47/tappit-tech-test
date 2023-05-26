import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";
import path from "path";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  resolve: {
    alias: [
      {
        find: "@components",
        replacement: path.resolve(__dirname, "./src/components"),
      },
      {
        find: "@routes",
        replacement: path.resolve(__dirname, "./src/routes"),
      },
      {
        find: "@services",
        replacement: path.resolve(__dirname, "./src/services"),
      },
      {
        find: "@shared",
        replacement: path.resolve(__dirname, "./src/shared"),
      },
    ],
  },
});
