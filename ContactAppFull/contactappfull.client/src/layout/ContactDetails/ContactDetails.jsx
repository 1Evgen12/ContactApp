import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import axios from "axios";
const baseApiUrl = import.meta.env.VITE_REACT_APP_API_URL;

const ContactDetails = () => {
    const [contact, setContact] = useState({ name: "", email: "" });
    const { id } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        const url = `${baseApiUrl}/contacts/${id}`;
        console.log(url);
        axios.get(url).then(
            response => setContact(response.data)
        ).catch(
            err => {
                console.log(err);
                navigate("/");
            }
        )
    }, [id, navigate])

    return <div className="container mt-5">
        <h2>Детали контакта</h2>
        <div className="mb-3">
            <label className="form-label">Имя: </label>
            <input
                className="form-control"
                type="text"
                value={contact.name}
                onChange={e => { }}
            />
        </div>
        <div className="mb-3">
            <label className="form-label">Email: </label>
            <input
                className="form-control"
                type="email"
                value={contact.email}
                onChange={e => { }}
            />
        </div>
        <div className="mb-3">
            <label className="form-label">Телефон: </label>
            <input
                className="form-control"
                type="text"
                value={contact.phoneNumber}
                onChange={e => { }}
            />
        </div>
        <div className="mb-3">
            <label className="form-label">Адрес: </label>
            <input
                className="form-control"
                type="text"
                value={contact.address}
                onChange={e => { }}
            />
        </div>
        <button
            className="btn btn-primary me-2"
            onClick={(e) => { }}>
            Обновить
        </button>
        <button
            className="btn btn-danger me-2"
            onClick={(e) => { }}>
            Удалить
        </button>
        <button
            className="btn btn-secondary me-2"
            onClick={(e) => { }}>
            Назад
        </button>
    </div>
}

export default ContactDetails;