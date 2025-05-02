<template>
  <div class="contact-list-container">
    <div class="form-box">
      <h2>{{ editingContact ? 'Edit Contact' : 'Add Contact' }}</h2>
      <!-- Form for Adding a New Contact -->
<form v-if="!editingContact" @submit.prevent="createContact" class="contact-form">
  <input v-model="newContact.fullName" type="text" placeholder="Name" required class="input-field" />
  <input v-model="newContact.email" type="email" placeholder="Email" required class="input-field" />
  <input v-model="newContact.phone" type="text" placeholder="Phone" required class="input-field" />
  <button type="submit" class="submit-button">Add Contact</button>
</form>

<!-- Form for Editing a Contact -->
<form v-else @submit.prevent="updateContact" class="contact-form">
  <input v-model="editingContact.fullName" type="text" placeholder="Name" required class="input-field" />
  <input v-model="editingContact.email" type="email" placeholder="Email" required class="input-field" />
  <input v-model="editingContact.phone" type="text" placeholder="Phone" required class="input-field" />
  <button type="submit" class="submit-button">Update Contact</button>
  <button @click="cancelEdit" type="button" class="cancel-button">Cancel</button>
</form>
    </div>

    <div class="contact-list-box">
      <h2>Contact List</h2>
      <div v-if="contacts.length" class="contact-list">
        <ul>
  <li v-for="contact in contacts" :key="contact.id" class="contact-item">
    <span>{{ contact.fullName }} - {{ contact.email }} - {{ contact.phone }}</span>
    <div class="contact-actions">
      <button @click="editContact(contact)" class="edit-button">Edit</button>
      <button @click="deleteContact(contact.id)" class="delete-button">Delete</button>
    </div>
  </li>
</ul>
      </div>
      <p v-else class="loading-text">Loading...</p>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'ContactList',
  data() {
    return {
      contacts: [],
      newContact: {
        fullName: '',
        email: '',
        phone: '',
        isFavorite: false
      },
      editingContact: null
    };
  },
  mounted() {
    this.fetchContacts();
  },
  methods: {
    // Fetch contacts from the backend
    fetchContacts() {
      axios.get('http://localhost:5180/api/contacts')
        .then(response => {
          this.contacts = response.data;
        })
        .catch(error => {
          console.error("Error fetching contacts:", error);
        });
    },

    // Add a new contact
    createContact() {
      axios.post('http://localhost:5180/api/contacts', this.newContact)
        .then(response => {
          this.contacts.push(response.data); // Add new contact to the list
          this.newContact = { fullName: '', email: '', phone: '' }; // Reset form
        })
        .catch(error => {
          console.error("Error creating contact:", error);
        });
    },

    // Start editing an existing contact
    editContact(contact) {
      this.editingContact = { ...contact }; 
    },

    // Update the edited contact
    updateContact() {
      axios.put(`http://localhost:5180/api/contacts/${this.editingContact.id}`, this.editingContact)
        .then(response => {
          const index = this.contacts.findIndex(contact => contact.id === this.editingContact.id);
          this.contacts.splice(index, 1, response.data); // Update the contact in the list
          this.editingContact = null; // Clear the editing form
        })
        .catch(error => {
          console.error("Error updating contact:", error);
        });
    },

    // Cancel the edit mode and clear the form
    cancelEdit() {
      this.editingContact = null; // Clear the editing form
    },

    // Delete a contact from the list
    deleteContact(id) {
      axios.delete(`http://localhost:5180/api/contacts/${id}`)
        .then(() => {
          this.contacts = this.contacts.filter(contact => contact.id !== id); // Remove contact from list
        })
        .catch(error => {
          console.error("Error deleting contact:", error);
        });
    }
  }
};
</script>

<style scoped>
/* Main container */
.contact-list-container {
  display: flex;
  justify-content: space-between;
  gap: 30px;
  padding: 30px;
  font-family: 'Arial', sans-serif;
  background-color: #f4f4f9;
  min-height: 100vh;
}

/* Form box */
.form-box {
  flex: 1;
  background-color: #ffffff;
  border-radius: 8px;
  box-shadow: 0 6px 12px rgba(0, 0, 0, 0.15); /* Enhanced shadow for sleek look */
  padding: 30px;
  width: 100%;
  max-width: 450px;
  transition: transform 0.3s ease;
}

.form-box:hover {
  transform: scale(1.02); /* Slight zoom effect on hover */
}

/* Contact list box */
.contact-list-box {
  flex: 2;
  background-color: #ffffff;
  border-radius: 8px;
  box-shadow: 0 6px 12px rgba(0, 0, 0, 0.15); /* Enhanced shadow */
  padding: 30px;
  width: 100%;
  max-width: 750px;
}

/* Title */
h1, h2 {
  color: #333;
  margin-bottom: 20px;
  font-size: 2rem;
}

/* Form container */
.contact-form {
  display: flex;
  flex-direction: column;
  gap: 20px;
}

/* Input fields */
.input-field {
  padding: 14px;
  border: 1px solid #ccc;
  border-radius: 5px;
  font-size: 1rem;
  outline: none;
  transition: border 0.3s ease;
}

.input-field:focus {
  border-color: #007BFF;
  box-shadow: 0 0 8px rgba(0, 123, 255, 0.3);
}

/* Buttons */
.submit-button, .cancel-button, .edit-button, .delete-button {
  padding: 12px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease, transform 0.3s ease;
}

.submit-button {
  background-color: #28a745;
  color: white;
  font-size: 1rem;
}

.submit-button:hover {
  background-color: #218838;
  transform: scale(1.05); /* Slight zoom effect */
}

.cancel-button {
  background-color: #dc3545;
  color: white;
  font-size: 1rem;
}

.cancel-button:hover {
  background-color: #c82333;
  transform: scale(1.05);
}

.edit-button {
  background-color: #007bff;
  color: white;
  font-size: 0.9rem;
}

.edit-button:hover {
  background-color: #0056b3;
  transform: scale(1.05);
}

.delete-button {
  background-color: #dc3545;
  color: white;
  font-size: 0.9rem;
}

.delete-button:hover {
  background-color: #c82333;
  transform: scale(1.05);
}

/* Contact list */
.contact-list {
  margin-top: 20px;
}

.contact-item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background-color: white;
  padding: 16px;
  margin-bottom: 15px;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  color: black; /* Ensure text is black */
  transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.contact-item:hover {
  transform: scale(1.02);
  box-shadow: 0 6px 12px rgba(0, 0, 0, 0.2); /* Highlight contact item */
}

/* Action buttons */
.contact-actions {
  display: flex;
  gap: 12px;
}

/* Loading text */
.loading-text {
  text-align: center;
  font-size: 1.2rem;
  color: #888;
}
</style>