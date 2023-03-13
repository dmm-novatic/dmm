import { notification } from 'antd';
import { useRouter } from 'next/router';
import React, { Component } from 'react';
import AccountRepository from '~/repositories/AccountRepository';
import AccountMenuSidebar from './modules/AccountMenuSidebar';
const UpdatePassword = ({}) => {
    const Router = useRouter();
    const accountLinks = [
        {
            text: 'Account Information',
            url: '/account/user-information',
            icon: 'icon-user',
        },
        {
            text: 'Update Password',
            url: '/account/updatePassword',
            active: true,
            icon: 'icon-key',
        },
        {
            text: 'Notifications',
            url: '/account/notifications',
            icon: 'icon-alarm-ringing',
        },
        {
            text: 'Invoices',
            url: '/account/invoices',
            icon: 'icon-papers',
        },
        {
            text: 'Address',
            url: '/account/addresses',
            icon: 'icon-map-marker',
        },
        {
            text: 'Order History',
            url: '/account/orderHistory',
            icon: 'icon-store',
        },
        {
            text: 'Wishlist',
            url: '/account/wishlist',
            icon: 'icon-heart',
        },
    ];
    const handleChangePassword = async () => {
        const userInfo = JSON.parse(localStorage.getItem('account'));
        const oldPassword = document.getElementById('oldPassword').value;
        const newPassword = document.getElementById('newPassword').value;
        const confirmPassword = document.getElementById('confirmPassword')
            .value;
        if (oldPassword === '') {
            notification['warn']({
                message: 'Update failed',
                description: 'Please input your old password',
            });
        } else if (newPassword === '') {
            notification['warn']({
                message: 'Update failed',
                description: 'Please input your new password',
            });
        } else if (confirmPassword === '') {
            notification['warn']({
                message: 'Update failed',
                description: 'Please input your confirm password',
            });
        } else if (newPassword !== confirmPassword) {
            notification['warn']({
                message: 'Update failed',
                description: 'New password not equal confirm password',
            });
        } else {
            const payload = {};
            payload.id = userInfo.id;
            payload.active = 1;
            payload.password = newPassword;
            payload.description = oldPassword;
            const result = await AccountRepository.updatePassword(payload);
            if (result) {
                notification['success']({
                    message: 'Update password success',
                });
                Router.push('/');
            }
        }
    };
    return (
        <section className="ps-my-account ps-page--account">
            <div className="container">
                <div className="row">
                    <div className="col-lg-4">
                        <div className="ps-page__left">
                            <AccountMenuSidebar data={accountLinks} />
                        </div>
                    </div>
                    <div className="col-lg-8">
                        <div className="ps-page__content">
                            <div
                                className="ps-section--account-setting"
                                style={{ width: '120%', height: '150%' }}>
                                <div className="ps-section__header">
                                    <h3>Order History</h3>
                                </div>
                                <div
                                    className="ps-section__content"
                                    style={{
                                        display: 'flex',
                                        flexDirection: 'column',
                                        justifyContent: 'space-bettween',
                                    }}>
                                    <input
                                        style={{ margin: '15px 0' }}
                                        placeholder="Input Old Password"
                                        id="oldPassword"
                                        defaultValue=""
                                        type='password'
                                    />
                                    <input
                                        style={{ margin: '15px 0' }}
                                        placeholder="Input New Password"
                                        id="newPassword"
                                        defaultValue=""
                                        type='password'
                                    />
                                    <input
                                        style={{ margin: '15px 0' }}
                                        placeholder="Confirm Password"
                                        id="confirmPassword"
                                        defaultValue=""
                                        type='password'
                                    />
                                    <button
                                        className="ps-btn"
                                        style={{ width: '40%' }}
                                        onClick={() => handleChangePassword()}>
                                        Update Password
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
};

export default UpdatePassword;
