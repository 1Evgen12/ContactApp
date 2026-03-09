import React from "react";
const FormContact = (props) => {
    return (
        <div>
            <div className="mb-3">
                <form>
                    <div className="mb-3">
                        <input className="form-control" type="text" placeholder="Введите имя:" />
                    </div>
                    <div className="mb-3">
                        {/* <label className="form-label">
                            Введите E-mail:
                        </label> */}
                        <input className="form-control" type="text" placeholder="Введите E-mail:" />
                    </div>
                    <div className="mb-3">
                        {/* <label className="form-label">
                            Введите номер телефона:
                        </label> */}
                        <input className="form-control" type="text" placeholder="Введите номер телефона:" />
                    </div>
                    <div className="mb-3">
                        {/* <label className="form-label">
                            Введите адрес:
                        </label> */}
                        <input className="form-control" type="text" placeholder="Введите адрес:" />
                    </div>
                </form>

            </div>
            <div>
                <button
                    className="btn btn-primary"
                    onClick={() => props.addContact()}
                >
                    Добавить контакт
                </button>
            </div>
        </div>
    );
}

export default FormContact