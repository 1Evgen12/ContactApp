import TableContact from "./layout/TableContact/TableContact";
import React, { useState, useEffect } from "react";
import axios from 'axios';
import { Route, Routes, useLocation, Link } from "react-router-dom";
import ContactDetails from "./layout/ContactDetails/ContactDetails";
import Pagination from "./layout/Pagination/Pagination";
import AppendContact from "./layout/FormContact/AppendContact";

const baseApiUrl = import.meta.env.VITE_REACT_APP_API_URL;

const App = () => {
  const [contacts, setContacts] = useState([]);
  const location = useLocation();
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(0);
  const [pageSize] = useState(10);
  const [updateTrigger, setUpdateTrigger] = useState(false);

  useEffect(() => {
    const url = `${baseApiUrl}/contacts/page?pageNumber=${currentPage}&pageSize=${pageSize}`;
    axios.get(url).then(
      res => {
        setContacts(res.data.contacts);
        setTotalPages(Math.ceil(res.data.totalCount / pageSize));
      });
  }, [currentPage, pageSize, location.pathname]);

  const handlePageChange = (pageNumber) => {
    setCurrentPage(pageNumber)
  }
  return (
    <div className="container mt-5">
      <Routes>
        <Route path="/" element={
          <div className="card">
            <div className="card-header">
              <h1>Список контактов</h1>
            </div>
            <div className="card-body">
              <TableContact contacts={contacts} />
              <Pagination
                currentPage={currentPage}
                totalPages={totalPages}
                onPageChange={handlePageChange}
              />
              <Link
                to="/append"
                className="btn btn-success mt-3">
                Добавить контакт
              </Link>
            </div>
          </div>
        } />
        <Route path="contact/:id" element={<ContactDetails onUpdate={handleUpdateTrigger} />} />
        <Route path="append" element={<AppendContact />} />
      </Routes>
    </div>
  );
}

export default App;
