import React, { useState } from "react";
const FormContact = (props) => {
    const [contactName, setContactName] = useState("")
    const [contactEmail, setContactEmail] = useState("")
    const [contactPhone, setContactPhone] = useState("")
    const [contactAddress, setContactAddress] = useState("")

    const submit = () => {

        if (contactName.trim() == "" || contactEmail.trim() == "" ||
            contactPhone.trim() == "" || contactAddress.trim() == "") {
            return;
        }
        props.addContact(contactName, contactEmail, contactPhone, contactAddress);
        setContactName("");
        setContactEmail("");
        setContactPhone("");
        setContactAddress("");
    }

    return (
        <div>
            <div className="mb-3">
                <form>
                    <div className="mb-3">
                        <label className="form-label">
                            Введите имя:
                        </label>
                        <input className="form-control" type="text"
                            placeholder="имя:"
                            onChange={(e) => { setContactName(e.target.value) }}
                            value={contactName} />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">
                            Введите E-mail:
                        </label>
                        <input className="form-control" type="text"
                            placeholder="e-mail:"
                            onChange={(e) => { setContactEmail(e.target.value) }}
                            value={contactEmail} />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">
                            Введите номер телефона:
                        </label>
                        <input className="form-control" type="text"
                            placeholder="телефон:"
                            onChange={(e) => { setContactPhone(e.target.value) }}
                            value={contactPhone} />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">
                            Введите адрес:
                        </label>
                        <input className="form-control" type="text"
                            placeholder="адрес:"
                            onChange={(e) => { setContactAddress(e.target.value) }}
                            value={contactAddress}
                        />
                    </div>
                </form>

            </div>
            <div>
                <button className="btn btn-primary" onClick={() => submit()}>
                    Добавить контакт
                </button>
            </div>
        </div>
    );
}

export default FormContact