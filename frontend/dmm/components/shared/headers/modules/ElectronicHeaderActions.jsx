import React from 'react';
import { connect } from 'react-redux';
import Link from 'next/link';
import AccountQuickLinks from '~/components/shared/headers/modules/AccountQuickLinks';
import { useState, useEffect } from 'react';

const ElectronicHeaderActions = ({ ecomerce }) => {
    const [account, setAccount] = useState([]);
    useEffect(() => {
        const userInfo = JSON.parse(localStorage.getItem('account'));
        if (!userInfo) {
            if (!userInfo && userInfo !== account) {
                setAccount(userInfo);
            }
        }
    });
    return (
        <div className="header__actions">
            <Link href="/account/wishlist">
                <a className="header__extra">
                    <i className="icon-heart"></i>
                    <span>
                        <i>{ecomerce.wishlistItems.length}</i>
                    </span>
                </a>
            </Link>
            {account && account !== null ? (
                <AccountQuickLinks isLoggedIn={true} />
            ) : (
                <AccountQuickLinks isLoggedIn={false} />
            )}
        </div>
    );
};

export default connect((state) => state)(ElectronicHeaderActions);
