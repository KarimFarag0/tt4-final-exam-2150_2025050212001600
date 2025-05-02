<script setup>
import WelcomeItem from './WelcomeItem.vue'

const openReadmeInEditor = () => fetch('/__open-in-editor?file=README.md')
</script>

<template>
  <WelcomeItem>
    <template #heading>Contact List Manager</template>
    Welcome to your personal contact management system. Use this tool to add, update, and organize your contacts efficiently.
  </WelcomeItem>

  <WelcomeItem>
    <template #heading>Features</template>
    - Add, edit, and delete contacts<br>
    - View your contact list in a clean and responsive interface<br>
    - Backend powered by ASP.NET Core Web API<br>
    - Frontend built with Vue 3 + Vite
  </WelcomeItem>

  <WelcomeItem>
    <template #heading>Getting Started</template>
    To get started, go to the <strong>Contacts</strong> section. You can add a new contact using the “Add Contact” button.
  </WelcomeItem>

  <WelcomeItem>
    <template #heading>Development</template>
    If you're working on this project, you can find more details and setup instructions in
    <a href="javascript:void(0)" @click="openReadmeInEditor"><code>README.md</code></a>.
  </WelcomeItem>

  <WelcomeItem>
    <template #heading>Support</template>
    If you encounter any issues or want to contribute, feel free to open a GitHub issue or pull request in the project repository.
  </WelcomeItem>
</template>