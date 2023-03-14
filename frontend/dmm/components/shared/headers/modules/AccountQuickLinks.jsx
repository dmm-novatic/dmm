import React, { useEffect } from 'react';
import { connect, useDispatch } from 'react-redux';
import Link from 'next/link';
import { useRouter } from 'next/router';
import { notification } from 'antd';
import { useState } from 'react';
const AccountQuickLinks = () => {
    const [isLoggedIns, setisLoggedIns] = useState(true);
    useEffect(() => {
        const userInfo = JSON.parse(localStorage.getItem('account'));
        if (userInfo === null) {
            setisLoggedIns(false);
        }
    });
    const Router = useRouter();
    const handleLogout = (e) => {
        e.preventDefault();
        notification['warning']({
            message: 'Good bye!',
            description: 'Your account has been logged out!',
        });
        localStorage.setItem('account', null);
        localStorage.setItem('cart', null);
        Router.push('/');
    };
    const accountLinks = [
        {
            text: 'Account Information',
            url: '/account/user-information',
        },
        {
            text: 'Update password',
            url: '/account/updatePassword',
        },
        {
            text: 'Notifications',
            url: '/account/notifications',
        },
        {
            text: 'Invoices',
            url: '/account/invoices',
        },
        {
            text: 'Address',
            url: '/account/addresses',
        },
        {
            text: 'Order History',
            url: '/account/orderHistory',
        },
        {
            text: 'Wishlist',
            url: '/account/wishlist',
        },
    ];

    // View
    const linksView = accountLinks.map((item) => (
        <li key={item.text}>
            <Link href={item.url}>
                <a>{item.text}</a>
            </Link>
        </li>
    ));

    if (isLoggedIns === true) {
        return (
            <div className="ps-block--user-account">
                <i className="icon-user"></i>
                <div className="ps-block__content">
                    <ul className="ps-list--arrow">
                        {linksView}
                        <li className="ps-block__footer">
                            <a href="#" onClick={(e) => handleLogout(e)}>
                                Logout
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        );
    } else {
        return (
            <div className="ps-block--user-header">
                <div className="ps-block__left">
                    <i className="icon-user"></i>
                </div>
                <div className="ps-block__right">
                    <Link href="/account/login">
                        <a>Login</a>
                    </Link>
                    <Link href="/account/register">
                        <a>Register</a>
                    </Link>
                </div>
            </div>
        );
    }
};

export default connect((state) => state)(AccountQuickLinks);
