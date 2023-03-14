import React, { Component, useEffect, useState } from 'react';
import { Table, Divider, Tag } from 'antd';
import NotificationRepository from '~/repositories/NotificationRepository';
import moment from 'moment';
import { ClipLoader } from 'react-spinners';
const TableNotifications = ({}) => {
    const [dataTable, setDataTable] = useState(null);
    const [isLoading, setIsLoading] = useState(false);
    const getNotiByAccount = async () => {
        const userInfo = JSON.parse(localStorage.getItem('account'));
        if (userInfo) {
            setIsLoading(false);
            const result = await NotificationRepository.getNotificationByAccount();
            if (result) {
                moment.locale('en');
                const dataTables = [];
                result.map((item, index) => {
                    const dataRow = {};
                    dataRow.key = index;
                    dataRow.id = item.id;
                    dataRow.notiStatusId = item.notificationStatusId;
                    dataRow.title = item.description;
                    dataRow.name = item.name;
                    dataRow.dateCreate = moment(item.createdTime).format(
                        'DD/MM/YYYY'
                    );
                    dataTables.push(dataRow);
                });
                setDataTable(dataTables);
                setIsLoading(true);
            }
        }
    };
    const markAsReadNoti = async (id) => {
        const payload = {};
        payload.id = id;
        const result = await NotificationRepository.markAsReadNotification(
            payload
        );
        if (result) {
            getNotiByAccount();
        }
    };
    useEffect(() => {
        getNotiByAccount();
    }, [5000]);
    const tableColumn = [
        {
            title: 'Date Create',
            dataIndex: 'dateCreate',
            key: 'dateCreate',
            render: (text) => <a>{text}</a>,
            width: '150px',
        },
        {
            title: 'Name',
            dataIndex: 'name',
            key: 'name',
        },
        {
            title: 'Title',
            dataIndex: 'title',
            key: 'title',
        },
        {
            title: 'Action',
            key: 'action',
            width: '200px',
            render: (text, record) => (
                <div>
                    {record.notiStatusId === 1000002 ? (
                        <span onClick={() => markAsReadNoti(text.id)}>
                            <a>Mark as read</a>
                        </span>
                    ) : (
                        <Tag color="volcano">Have Read</Tag>
                    )}
                </div>
            ),
        },
    ];
    return !isLoading ? (
        <div
            style={{
                width: '100%',
                display: 'flex',
                alignItems: 'center',
                marginTop: '40px',
                flexDirection: 'column',
            }}>
            <ClipLoader color="#fcb800"></ClipLoader>
            <h4 style={{ marginTop: '30px', color: '#fcb800' }}>Is Loading</h4>
        </div>
    ) : (
        <Table columns={tableColumn} dataSource={dataTable} />
    );
};

export default TableNotifications;
