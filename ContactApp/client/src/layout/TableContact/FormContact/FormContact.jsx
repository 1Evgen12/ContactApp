import React, { useState } from "react";
const FormContact = (props) => {
    const [contactName, setContactName] = useState("")
    const [contactEmail, setContactEmail] = useState("")
    const [contactPhone, setContactPhone] = useState("")
    const [contactAddress, setContactAddress] = useState("")

    const submit = () => {
        props.addContact(contactName, contactEmail, contactPhone, contactAddress)
    }

    return (
        <div>
            <div className="mb-3">
                <form>
                    <div className="mb-3">
                        <input className="form-control" type="text"
                            placeholder="Введите имя:"
                            onChange={(e) => { setContactName(e.target.value) }} />
                    </div>
                    <div className="mb-3">
                        {/* <label className="form-label">
                            Введите E-mail:
                        </label> */}
                        <input className="form-control" type="text"
                            placeholder="Введите E-mail:"
                            onChange={(e) => { setContactEmail(e.target.value) }} />
                    </div>
                    <div className="mb-3">
                        {/* <label className="form-label">
                            Введите номер телефона:
                        </label> */}
                        <input className="form-control" type="text"
                            placeholder="Введите номер телефона:"
                            onChange={(e) => { setContactPhone(e.target.value) }} />
                    </div>
                    <div className="mb-3">
                        {/* <label className="form-label">
                            Введите адрес:
                        </label> */}
                        <input className="form-control" type="text"
                            placeholder="Введите адрес:"
                            onChange={(e) => { setContactAddress(e.target.value) }}
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