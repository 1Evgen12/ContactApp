import FormContact from "./layout/TableContact/FormContact/FormContact";
import TableContact from "./layout/TableContact/TableContact";
import React, { useState } from "react";

const App = () => {
  const [contacts, setContacts] = useState([
    { id: 1, name: "Имя Фамилия 1", email: "q@e1.rt", phone: "phone 1", address: "address 1" },
    { id: 2, name: "Имя Фамилия 2", email: "q@e2.rt", phone: "phone 2", address: "address 2" },
    { id: 3, name: "Имя Фамилия 3", email: "q@e3.rt", phone: "phone 3", address: "address 3" },
  ])

  const addContact = () => {
    const Id = Math.max(...contacts.map(e => e.id)) + 1;
    const item = {
      id: Id,
      name: "Имя Фамилия 1",
      email: "q@e1.rt",
      phone: "phone 1",
      address: "address 1"
    }
    setContacts([...contacts, item]);
  }

  return (
    <div className="container mt-5">
      <div className="card">
        <div className="card-header">
          <h1>Список контактов</h1>
        </div>

        <div className="card-body">
          <TableContact contacts={contacts} />
          <FormContact addContact={addContact} />
        </div>
      </div>
    </div>
  );
}

export default App;
