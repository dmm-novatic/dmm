import React, { Component } from 'react';
import Link from 'next/link';
import Router from 'next/router';
import { login } from '../../../store/auth/action';

import { Form, Input, notification } from 'antd';
import { connect } from 'react-redux';
import AccountRepository from '~/repositories/AccountRepository';
import { RadioGroup, Radio } from 'react-radio-group';

class Register extends Component {
    constructor(props) {
        super(props);
        this.state = {
            isCompany: 'personal',
        };
    }
    handleSubmit = (e) => {
        e.preventDefault();
        this.props.form.validateFields((err, values) => {
            if (!err) {
                this.props.dispatch(login());
                Router.push('/account/login');
            } else {
            }
        });
    };
    handleSelectRadio(value) {
        this.setState({ isCompany: value });
    }
    async handleRegist(e) {
        const name = document.getElementById('input_name').value;
        const userName = document.getElementById('input_userName').value;
        const email = document.getElementById('input_email').value;
        const password = document.getElementById('input_password').value;
        const rePassword = document.getElementById('input_rePassword').value;
        const phoneNumber = document.getElementById('input_phone').value;
        const idCard = document.getElementById('input_card').value;
        if (password !== rePassword) {
            notification['warning']({
                message: 'Confirm password incorect',
                description: 'Please Enter Corfirm PassWord again',
            });
        } else if (isNaN(phoneNumber)) {
            notification['warning']({
                message: 'Regist Fail',
                description: 'Phone Number must be a number',
            });
        } else if (isNaN(idCard)) {
            notification['warning']({
                message: 'Regist Fail',
                description: 'ID Card Number must be a number',
            });
        } else {
            const payload = {};
            if (this.state.isCompany === 'company') {
                payload.CompanyName = document.getElementById(
                    'input_companyName'
                ).value;
                payload.CompanyNumber = document.getElementById(
                    'input_companyNumber'
                ).value;
                payload.AccountTypeId = '20001';
            } else {
                payload.AccountTypeId = '30001';
                payload.CompanyName = '';
                payload.CompanyNumber = '';
            }
            payload.Description = '';
            payload.IdCardNumber = idCard;
            payload.Info = '';
            payload.Phone = phoneNumber;
            payload.IsActivated = 1;
            payload.Photo =
                'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRSgiBXKS7_rYOPdUxh1W9sSbmg-0y5MeIxXQImvfmGmRvjz5q-&s';

            payload.active = 1;
            payload.address = '';
            payload.email = email;
            payload.name = name;
            payload.userName = userName;
            payload.password = password;
            const result = await AccountRepository.registAccount(payload);
            if (result) {
                Router.push('/');
            }
        }
    }
    render() {
        return (
            <div className="ps-my-account">
                <div className="container">
                    <Form
                        className="ps-form--account"
                        onSubmit={this.handleSubmit}>
                        <ul className="ps-tab-list">
                            <li>
                                <Link href="/account/login">
                                    <a>Login</a>
                                </Link>
                            </li>
                            <li className="active">
                                <Link href="/account/register">
                                    <a>Register</a>
                                </Link>
                            </li>
                        </ul>
                        <div className="ps-tab active" id="register">
                            <div className="ps-form__content">
                                <h5>Register An Account</h5>
                                <RadioGroup
                                    name="Regist"
                                    selectedValue={this.state.isCompany}
                                    style={{
                                        display: 'flex',
                                        justifyContent: 'space-around',
                                    }}
                                    onChange={this.handleSelectRadio.bind(
                                        this
                                    )}>
                                    <label>
                                        <Radio value="personal"></Radio>
                                        Personal
                                    </label>
                                    <label>
                                        <Radio value="company"></Radio>
                                        Enterprise
                                    </label>
                                </RadioGroup>
                                <div className="form-group">
                                    <Form.Item
                                        name="fullName"
                                        rules={[
                                            {
                                                required: true,
                                                message:
                                                    'Please input your full name!',
                                            },
                                        ]}>
                                        <Input
                                            id="input_name"
                                            className="form-control"
                                            placeholder="Name"
                                        />
                                    </Form.Item>
                                </div>
                                <div className="form-group">
                                    <Form.Item
                                        name="UserName"
                                        rules={[
                                            {
                                                required: true,
                                                message:
                                                    'Please input your user name!',
                                            },
                                        ]}>
                                        <Input
                                            id="input_userName"
                                            className="form-control"
                                            placeholder="User Name"
                                        />
                                    </Form.Item>
                                </div>
                                <div className="form-group">
                                    <Form.Item
                                        name="email"
                                        rules={[
                                            {
                                                required: true,
                                                message:
                                                    'Please input your email!',
                                            },
                                        ]}>
                                        <Input
                                            id="input_email"
                                            className="form-control"
                                            type="email"
                                            placeholder="Email address"
                                        />
                                    </Form.Item>
                                </div>
                                <div className="form-group form-forgot">
                                    <Form.Item
                                        name="password"
                                        rules={[
                                            {
                                                required: true,
                                                message:
                                                    'Please input your password!',
                                            },
                                        ]}>
                                        <Input
                                            id="input_password"
                                            className="form-control"
                                            type="password"
                                            placeholder="Password..."
                                        />
                                    </Form.Item>
                                </div>
                                <div className="form-group form-forgot">
                                    <Form.Item
                                        name="re-password"
                                        rules={[
                                            {
                                                required: true,
                                                message:
                                                    'Please input your re-password!',
                                            },
                                        ]}>
                                        <Input
                                            id="input_rePassword"
                                            className="form-control"
                                            type="password"
                                            placeholder="Re-Password"
                                        />
                                    </Form.Item>
                                </div>
                                <div className="form-group">
                                    <Form.Item
                                        name="Phone Number"
                                        rules={[
                                            {
                                                required: true,
                                                message:
                                                    'Please input your phone number!',
                                            },
                                        ]}>
                                        <Input
                                            id="input_phone"
                                            className="form-control"
                                            placeholder="Phone Number"
                                        />
                                    </Form.Item>
                                </div>
                                <div className="form-group">
                                    <Form.Item
                                        name="IDCard"
                                        rules={[
                                            {
                                                required: true,
                                                message:
                                                    'Please input your ID card!',
                                            },
                                        ]}>
                                        <Input
                                            id="input_card"
                                            className="form-control"
                                            placeholder="ID card"
                                        />
                                    </Form.Item>
                                </div>
                                {this.state.isCompany === 'company' && (
                                    <div className="form-group">
                                        <Form.Item
                                            name="companyName"
                                            rules={[
                                                {
                                                    required: true,
                                                    message:
                                                        'Please input your Company Name!',
                                                },
                                            ]}>
                                            <Input
                                                id="input_companyName"
                                                className="form-control"
                                                placeholder="Company Name"
                                            />
                                        </Form.Item>
                                        <Form.Item
                                            name="companyNumber"
                                            rules={[
                                                {
                                                    required: true,
                                                    message:
                                                        'Please input your Company Number!',
                                                },
                                            ]}>
                                            <Input
                                                id="input_companyNumber"
                                                className="form-control"
                                                placeholder="Company Number"
                                            />
                                        </Form.Item>
                                    </div>
                                )}
                                <div className="form-group submit">
                                    <button
                                        onClick={this.handleRegist.bind(this)}
                                        type="submit"
                                        className="ps-btn ps-btn--fullwidth">
                                        Register
                                    </button>
                                </div>
                            </div>
                            <div className="ps-form__footer">
                                <p>Connect with:</p>
                                <ul className="ps-list--social">
                                    <li>
                                        <a className="facebook" href="#">
                                            <i className="fa fa-facebook"></i>
                                        </a>
                                    </li>
                                    <li>
                                        <a className="google" href="#">
                                            <i className="fa fa-google-plus"></i>
                                        </a>
                                    </li>
                                    <li>
                                        <a className="twitter" href="#">
                                            <i className="fa fa-twitter"></i>
                                        </a>
                                    </li>
                                    <li>
                                        <a className="instagram" href="#">
                                            <i className="fa fa-instagram"></i>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </Form>
                </div>
            </div>
        );
    }
}

const mapStateToProps = (state) => {
    return state.auth;
};
export default connect(mapStateToProps)(Register);
