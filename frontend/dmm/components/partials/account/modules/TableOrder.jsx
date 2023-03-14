import React, { useEffect, useState } from 'react';
import { notification, Table } from 'antd';
import { ClipLoader } from 'react-spinners';
import OrderRepository from '~/repositories/OrderRepository';
import moment from 'moment';
import { Modal } from 'antd';
const TableOrder = ({
    idRender,
    waitingConfirm = false,
    finishOrder = false,
}) => {
    const [dataTable, setDataTable] = useState(null);
    const [isLoading, setIsLoading] = useState(false);
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [dataDetail, setDataDetail] = useState([]);
    const getOrderHistory = async () => {
        const userInfo = JSON.parse(localStorage.getItem('account'));
        if (userInfo) {
            setIsLoading(false);
            const result = await OrderRepository.getOrderHistory(idRender);
            if (result) {
                console.log('result', result);
                const dataTables = [];
                moment.locale('en');
                result.map((item, index) => {
                    const dataRow = {};
                    dataRow.id = item.id;
                    dataRow.finalPrice = item.finalPrice;
                    dataRow.shopName = item.name;
                    dataRow.info = item.info;
                    dataRow.dateOrder = moment(item.createdTime).format(
                        'DD/MM/YYYY'
                    );
                    dataRow.paymaentStatus = item.orderPaymentStatus.name;
                    dataRow.shipStatus = item.orderStatus.name;
                    dataRow.deliveryCode = item.deliveryCode;
                    dataRow.shippingUnit = item.shippingUnit;
                    dataTables.push(dataRow);
                });
                setDataTable(dataTables);
            }
            setIsLoading(true);
        }
    };
    const showDetail = async (id) => {
        setDataDetail([]);
        const result = await OrderRepository.getOrderDetail(id);
        if (result) {
            setDataDetail(result);
        }
        setIsModalVisible(true);
    };
    const cancelOrder = async (id) => {
        const payload = {};
        payload.id = id;
        const result = await OrderRepository.cancelOrderDetail(payload);
        if (result) {
            notification['success']({
                message: 'Cancel order success',
                description: 'Your Order have been cancel',
            });
            getOrderHistory();
        }
    };
    useEffect(() => {
        getOrderHistory();
    }, [5000]);
    const tableColumn = [
        {
            title: 'Date Order',
            dataIndex: 'dateOrder',
            key: 'dateOrder',
            render: (text) => <a>{text}</a>,
            width: '100px',
        },
        {
            title: 'Shop Name',
            dataIndex: 'shopName',
            key: 'shopName',
        },
        {
            title: 'Info',
            dataIndex: 'info',
            key: 'info',
        },
        {
            title: 'Final Price',
            dataIndex: 'finalPrice',
            key: 'finalPrice',
        },
        {
            title: 'Payment Status',
            dataIndex: 'paymaentStatus',
            key: 'paymaentStatus',
        },
        {
            title: 'Delivery Code',
            dataIndex: 'deliveryCode',
            key: 'deliveryCode',
        },
        {
            title: 'Shipping Unit',
            dataIndex: 'shippingUnit',
            key: 'shippingUnit',
        },
        {
            title: 'Action',
            key: 'action',
            width: '200px',
            render: (text) => (
                <div>
                    <span
                        style={{ color: '#1890ff' }}
                        onClick={() => showDetail(text.id)}>
                        <a>Show Detail</a>
                    </span>
                </div>
            ),
        },
    ];
    const tableColumnFinish = [
        {
            title: 'Date Order',
            dataIndex: 'dateOrder',
            key: 'dateOrder',
            render: (text) => <a>{text}</a>,
            width: '100px',
        },
        {
            title: 'Shop Name',
            dataIndex: 'shopName',
            key: 'shopName',
        },
        {
            title: 'Info',
            dataIndex: 'info',
            key: 'info',
        },
        {
            title: 'Final Price',
            dataIndex: 'finalPrice',
            key: 'finalPrice',
        },
        {
            title: 'Payment Status',
            dataIndex: 'paymaentStatus',
            key: 'paymaentStatus',
        },
        {
            title: 'Action',
            key: 'action',
            width: '200px',
            render: (text) => (
                <div>
                    <span
                        style={{ color: '#1890ff' }}
                        onClick={() => showDetail(text.id)}>
                        <a>Show Detail</a>
                    </span>
                </div>
            ),
        },
    ];
    const tableColumnWaiting = [
        {
            title: 'Date Order',
            dataIndex: 'dateOrder',
            key: 'dateOrder',
            render: (text) => <a>{text}</a>,
            width: '100px',
        },
        {
            title: 'Shop Name',
            dataIndex: 'shopName',
            key: 'shopName',
        },
        {
            title: 'Info',
            dataIndex: 'info',
            key: 'info',
        },
        {
            title: 'Final Price',
            dataIndex: 'finalPrice',
            key: 'finalPrice',
        },
        {
            title: 'Payment Status',
            dataIndex: 'paymaentStatus',
            key: 'paymaentStatus',
        },
        {
            title: 'Ship Status',
            dataIndex: 'shipStatus',
            key: 'shipStatus',
        },
        {
            title: 'Action',
            key: 'action',
            width: '200px',
            render: (text) => (
                <div style={{ display: 'flex', flexDirection: 'column' }}>
                    <span
                        style={{ color: '#1890ff' }}
                        onClick={() => showDetail(text.id)}>
                        <a>Show Detail</a>
                    </span>
                    {waitingConfirm === true && (
                        <span
                            style={{ paddingTop: '5px', color: 'red' }}
                            onClick={() => cancelOrder(text.id)}>
                            <a>Cancel</a>
                        </span>
                    )}
                </div>
            ),
        },
    ];

    const currencyFormat = (num) => {
        return (
            num.toFixed(0).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,') + ' vnd'
        );
    };
    return (
        <div>
            {!isLoading ? (
                <div
                    style={{
                        width: '100%',
                        display: 'flex',
                        alignItems: 'center',
                        marginTop: '40px',
                        flexDirection: 'column',
                    }}>
                    <ClipLoader color="#fcb800"></ClipLoader>
                    <h4 style={{ marginTop: '30px', color: '#fcb800' }}>
                        Is Loading
                    </h4>
                </div>
            ) : (
                <div>
                    <Table
                        columns={
                            waitingConfirm
                                ? tableColumnWaiting
                                : finishOrder
                                ? tableColumnFinish
                                : tableColumn
                        }
                        dataSource={dataTable}
                    />
                    {dataDetail !== null && (
                        <Modal
                            onOk={() => setIsModalVisible(false)}
                            visible={isModalVisible}>
                            {dataDetail.map((item) => {
                                return (
                                    <div
                                        key={item.id}
                                        style={{ borderBottom: '1px solid' }}>
                                        <div
                                            style={{
                                                width: '90%',
                                                display: 'flex',
                                                justifyContent: 'space-between',
                                            }}>
                                            <strong
                                                style={{ paddingRight: '5px' }}>
                                                Description:
                                            </strong>
                                            <div>{item.description}</div>
                                        </div>
                                        <div
                                            style={{
                                                width: '90%',
                                                display: 'flex',
                                                justifyContent: 'space-between',
                                            }}>
                                            <strong
                                                style={{ paddingRight: '5px' }}>
                                                Name:{' '}
                                            </strong>
                                            <span>{item.name}</span>
                                        </div>
                                        <div
                                            style={{
                                                width: '90%',
                                                display: 'flex',
                                                justifyContent: 'space-between',
                                            }}>
                                            <strong
                                                style={{ paddingRight: '5px' }}>
                                                Image:{' '}
                                            </strong>
                                            <img
                                                style={{ width: '80px' }}
                                                src={item.photo}></img>
                                        </div>
                                        <div
                                            style={{
                                                width: '90%',
                                                display: 'flex',
                                                justifyContent: 'space-between',
                                            }}>
                                            <strong
                                                style={{ paddingRight: '5px' }}>
                                                Quantity:{' '}
                                            </strong>
                                            <span>{item.quantity}</span>
                                        </div>
                                        <div
                                            style={{
                                                width: '90%',
                                                display: 'flex',
                                                justifyContent: 'space-between',
                                            }}>
                                            <strong
                                                style={{ paddingRight: '5px' }}>
                                                Price:{' '}
                                            </strong>
                                            <span>
                                                {currencyFormat(
                                                    item.price * item.quantity
                                                )}
                                            </span>
                                        </div>
                                    </div>
                                );
                            })}
                            {dataDetail && dataDetail[0] && (
                                <div>
                                    <strong>Total Price: </strong>
                                    <span>
                                        {currencyFormat(
                                            dataDetail[0].totalPrice
                                        )}
                                    </span>
                                </div>
                            )}
                        </Modal>
                    )}
                </div>
            )}
        </div>
    );
};

export default TableOrder;
