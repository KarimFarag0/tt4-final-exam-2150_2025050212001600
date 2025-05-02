<template>
    <div>
      <h1>Contact List</h1>
      <ul v-if="contacts.length">
        <li v-for="contact in contacts" :key="contact.id">
          {{ contact.name }} - {{ contact.email }} - {{ contact.phone }}
        </li>
      </ul>
      <p v-else>Loading...</p>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    name: 'ContactList',
    data() {
      return {
        contacts: []
      };
    },
    mounted() {
      axios.get('https://localhost:5180/api/contacts') 
        .then(response => {
          this.contacts = response.data;
        })
        .catch(error => {
          console.error("Error fetching contacts:", error);
        });
    }
  };
  </script>