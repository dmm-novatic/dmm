import React, { useEffect, useState } from 'react';
import Link from 'next/link';

const Addresses = ({}) => {
    const [account, setAccount] = useState([]);
    const accountLinks = [
        {
            text: 'Account Information',
            url: '/account/user-information',
            icon: 'icon-user',
        },
        {
            text: 'Update Password',
            url: '/account/updatePassword',
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
            active: true,
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
    useEffect(() => {
        const userInfo = JSON.parse(localStorage.getItem('account'));
        if (userInfo) {
            if (JSON.stringify(userInfo) !== JSON.stringify(account)) {
                setAccount(userInfo);
            }
        }
    });
    return (
        <section className="ps-my-account ps-page--account">
            <div className="container">
                <div className="row">
                    <div className="col-lg-4">
                        <div className="ps-section__left">
                            <aside className="ps-widget--account-dashboard">
                                <div className="ps-widget__header">
                                    <img
                                        src={
                                            account && account.photo
                                                ? account.photo
                                                : '/static/img/users/3.jpg'
                                        }
                                    />
                                    <figure>
                                        <figcaption>Hello</figcaption>
                                        <p>{account.name}</p>
                                    </figure>
                                </div>
                                <div className="ps-widget__content">
                                    <ul>
                                        {accountLinks.map((link) => (
                                            <li
                                                key={link.text}
                                                className={
                                                    link.active ? 'active' : ''
                                                }>
                                                <Link href={link.url}>
                                                    <a>
                                                        <i
                                                            className={
                                                                link.icon
                                                            }></i>
                                                        {link.text}
                                                    </a>
                                                </Link>
                                            </li>
                                        ))}
                                    </ul>
                                </div>
                            </aside>
                        </div>
                    </div>
                    <div className="col-lg-8">
                        <div className="ps-section--account-setting">
                            <div className="ps-section__content">
                                <div className="row">
                                    {account && account.address && (
                                        <div className="col-md-6 col-12">
                                            <input value={account.address} />
                                        </div>
                                    )}
                                    {account && account.addressCity && (
                                        <div className="col-md-6 col-12">
                                            <input
                                                value={account.addressCity}
                                            />
                                        </div>
                                    )}
                                    {account && account.addressDistrict && (
                                        <div className="col-md-6 col-12">
                                            <input
                                                value={account.addressDistrict}
                                            />
                                        </div>
                                    )}
                                    {account && account.addressWard && (
                                        <div className="col-md-6 col-12">
                                            <input
                                                value={account.addressWard}
                                            />
                                        </div>
                                    )}
                                    {!account.address &&
                                        !account.addressCity &&
                                        !account.addressDistrict &&
                                        !account.addressWard && (
                                            <strong>
                                                User has not update Address yet
                                            </strong>
                                        )}
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
};

export default Addresses;
