import React from 'react';
import { connect } from 'react-redux';
import Link from 'next/link';
import AccountQuickLinks from '~/components/shared/headers/modules/AccountQuickLinks';
import { useState, useEffect } from 'react';
import Notification from './Notification';
import CartRepository from '~/repositories/CartRepository';

const HeaderActions = ({ ecomerce }) => {
    const [account, setAccount] = useState([]);
    const [amountItem, setAmountItem] = useState(0);
    useEffect(() => {
        const userInfo = JSON.parse(localStorage.getItem('account'));
        if (!userInfo) {
            if (!userInfo && userInfo !== account) {
                setAccount(userInfo);
            }
        }
        if (userInfo) {
            countCartItem();
        }
    });
    const countCartItem = async () => {
        const result = await CartRepository.countCartItem();
        if (result) {
            setAmountItem(result);
        }
    };
    const { compareItems } = ecomerce;
    // views
    let headerAuthView;
    headerAuthView = <AccountQuickLinks />;
    return (
        <div className="header__actions">
            <Link href="/account/compare">
                <a className="header__extra">
                    <i className="icon-chart-bars"></i>
                    <span>
                        <i>{compareItems ? compareItems.length : 0}</i>
                    </span>
                </a>
            </Link>
            <Link href={account ? '/cart' : '/account/login'}>
                <div className="ps-cart--mini">
                    <a className="header__extra">
                        <i className="icon-bag2"></i>
                        <span>
                            <i>{amountItem}</i>
                        </span>
                    </a>
                </div>
            </Link>
            <Notification />
            {headerAuthView}
        </div>
    );
};

export default connect((state) => state)(HeaderActions);
