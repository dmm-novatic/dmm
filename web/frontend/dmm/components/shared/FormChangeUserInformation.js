import React, { useEffect, useState } from 'react';
import AccountRepository from '~/repositories/AccountRepository';
import _ from 'lodash';
import { notification } from 'antd';
const FormChangeUserInformation = ({ data }) => {
    const [dataUser, setDataUser] = useState();
    useEffect(() => {
        if (!dataUser || dataUser.length === 0) {
            setDataUser(JSON.parse(JSON.stringify(data)));
        }
    });
    const handleUpdateProfile = async () => {
        const payload = {};
        payload.username = dataUser.username;
        payload.email = dataUser.email;
        payload.name = dataUser.name;
        payload.phone = dataUser.phone;
        payload.idCardNumber = dataUser.idCardNumber;
        payload.companyName = dataUser.companyName;
        payload.companyNumber = dataUser.companyNumber;
        payload.id = dataUser.id;
        payload.accountTypeID = dataUser.accountTypeID;
        payload.active = dataUser.active;
        payload.password = dataUser.password;
        payload.description = dataUser.description;
        payload.info = dataUser.info;
        payload.createdTime = dataUser.createdTime;
        payload.address = dataUser.address;
        payload.isActivated = dataUser.isActivated;
        payload.photo = dataUser.photo;
        payload.googleId = null;
        payload.facebookId = null;
        if (!_.isEqual(dataUser, data)) {
            const result = await AccountRepository.updateAccount(payload);
            if (result) {
                localStorage.setItem('account', JSON.stringify(dataUser));
                notification['success']({
                    message: 'Update success',
                    description: 'Update account information success',
                });
            }
        } else {
            notification['warn']({
                message: 'Update failed',
                description: 'You must change account information',
            });
        }
    };
    return (
        <div className="ps-form--account-setting">
            <div className="ps-form__header">
                <h3>Account Information</h3>
            </div>
            <div className="ps-form__content">
                <div className="form-group">
                    <span>User Name</span>
                    <input
                        className="form-control"
                        type="text"
                        onChange={(e) => {
                            setDataUser((current) => {
                                return { ...current, username: e.target.value };
                            });
                        }}
                        value={
                            dataUser && dataUser.username
                                ? dataUser.username
                                : 'Username or email address'
                        }
                    />
                </div>
                <div className="row">
                    <div className="col-sm-6">
                        <div className="form-group">
                            <span>Name</span>
                            <input
                                className="form-control"
                                type="text"
                                onChange={(e) => {
                                    setDataUser((current) => {
                                        return {
                                            ...current,
                                            name: e.target.value,
                                        };
                                    });
                                }}
                                value={
                                    dataUser && dataUser.name
                                        ? dataUser.name
                                        : 'First name'
                                }
                            />
                        </div>
                    </div>
                    <div className="col-sm-6">
                        <div className="form-group">
                            <span>Phone</span>
                            <input
                                className="form-control"
                                type="text"
                                onChange={(e) => {
                                    setDataUser((current) => {
                                        return {
                                            ...current,
                                            phone: e.target.value,
                                        };
                                    });
                                }}
                                value={
                                    dataUser && dataUser.phone
                                        ? dataUser.phone
                                        : 'Phone Number'
                                }
                            />
                        </div>
                    </div>
                    <div className="col-sm-6">
                        <div className="form-group">
                            <span>Email</span>
                            <input
                                className="form-control"
                                type="text"
                                onChange={(e) => {
                                    setDataUser((current) => {
                                        return {
                                            ...current,
                                            email: e.target.value,
                                        };
                                    });
                                }}
                                value={
                                    dataUser && dataUser.email
                                        ? dataUser.email
                                        : 'Email Address'
                                }
                            />
                        </div>
                    </div>
                    <div className="col-sm-12">
                        <div className="form-group">
                            <span>Address</span>
                            <input
                                className="form-control"
                                type="text"
                                onChange={(e) => {
                                    setDataUser((current) => {
                                        return {
                                            ...current,
                                            address: e.target.value,
                                        };
                                    });
                                }}
                                value={
                                    dataUser && dataUser.address
                                        ? dataUser.address
                                        : 'Address'
                                }
                            />
                        </div>
                    </div>
                    <div className="col-sm-6">
                        <div className="form-group">
                            <span>Address City</span>
                            <input
                                className="form-control"
                                type="text"
                                onChange={(e) => {
                                    setDataUser((current) => {
                                        return {
                                            ...current,
                                            addressCity: e.target.value,
                                        };
                                    });
                                }}
                                value={
                                    dataUser && dataUser.addressCity
                                        ? dataUser.addressCity
                                        : 'City'
                                }
                            />
                        </div>
                    </div>
                    <div className="col-sm-6">
                        <div className="form-group">
                            <span>Address District</span>
                            <input
                                className="form-control"
                                type="text"
                                onChange={(e) => {
                                    setDataUser((current) => {
                                        return {
                                            ...current,
                                            addressDistrict: e.target.value,
                                        };
                                    });
                                }}
                                value={
                                    dataUser && dataUser.addressDistrict
                                        ? dataUser.addressDistrict
                                        : 'Country'
                                }
                            />
                        </div>
                    </div>
                </div>

                <div className="form-group submit">
                    <button
                        className="ps-btn"
                        onClick={() => handleUpdateProfile()}>
                        Update profile
                    </button>
                </div>
            </div>
        </div>
    );
};

export default FormChangeUserInformation;
