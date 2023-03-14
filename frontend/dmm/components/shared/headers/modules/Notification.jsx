import React, { useEffect, useState } from 'react';
import NotificationRepository from '~/repositories/NotificationRepository';
import Link from 'next/link';
const Notification = ({}) => {
    const [listNotification, setListNotification] = useState([]);
    const [notificationNonRead, setNotificationNonRead] = useState(0);
    const [userInfo, setUserInfo] = useState(null);
    const getNotification = async () => {
        const userInfo = JSON.parse(localStorage.getItem('account'));
        if (userInfo != null) {
            setUserInfo(userInfo);
            const result = await NotificationRepository.getNotificationByAccountId(
                1,
                5
            );
            getNotificationNonRead(userInfo);
            if (result) {
                setListNotification(result);
            }
        }
    };
    const getNotificationNonRead = async (userInfo) => {
        if (userInfo != null) {
            setUserInfo(userInfo);
            const result = await NotificationRepository.getNotificationNonReadByAccount();
            if (result) {
                setNotificationNonRead(result);
            }
        }
    };
    useEffect(() => {
        getNotification();
    }, [10000]);
    return (
        <div className="ps-cart--mini">
            <a className="header__extra" href="#">
                <i className="icon-alarm-ringing"></i>
                <span>
                    <i>{notificationNonRead}</i>
                </span>
            </a>
            <div className="ps-cart__content">
                <div className="ps-cart_header">New Notification</div>
                {listNotification &&
                    listNotification.map((item) => {
                        return (
                            <div className="ps-cart__items" key={item.id}>
                                <div style={{ fontWeight: '1000' }}>
                                    {item.name}
                                </div>
                                <div style={{ paddingLeft: '10px' }}>
                                    {item.description}
                                </div>
                            </div>
                        );
                    })}
                {userInfo !== null && (
                    <div className="ps-cart__footer">
                        <Link href="/account/notifications">
                            <a>Show more</a>
                        </Link>
                    </div>
                )}
            </div>
        </div>
    );
};
export default Notification;
