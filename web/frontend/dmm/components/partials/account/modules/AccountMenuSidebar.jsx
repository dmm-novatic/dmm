import React, { useEffect, useState } from 'react';
import Link from 'next/link';

const AccountMenuSidebar = ({ data }) => {
    const [account, setAccount] = useState(null);
    useEffect(() => {
        if (account === null) {
            const userInfo = JSON.parse(localStorage.getItem('account'));
            setAccount(userInfo);
        }
    });
    return (
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
                    <p>{account && account.name}</p>
                </figure>
            </div>
            <div className="ps-widget__content">
                <ul>
                    {data.map((link) => (
                        <li
                            key={link.text}
                            className={link.active ? 'active' : ''}>
                            <Link href={link.url}>
                                <a>
                                    <i className={link.icon}></i>
                                    {link.text}
                                </a>
                            </Link>
                        </li>
                    ))}
                </ul>
            </div>
        </aside>
    );
};

export default AccountMenuSidebar;
