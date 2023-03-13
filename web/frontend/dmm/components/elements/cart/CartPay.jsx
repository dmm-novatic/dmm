import { Modal, notification } from 'antd';
import React, { useEffect, useState } from 'react';
import VoucherRepository from '~/repositories/VoucherRepository';
import LocationForm from '../selectLocation/LocationForm';
const CartPay = ({ source, handleCheckBoxAll }) => {
    const [totalMoney, setTotalMoney] = useState(0);
    const [voucherAccept, setVoucherAccept] = useState();
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [dataOrder, setDataOrder] = useState([]);
    const totalPay = () => {
        const total = 0;
        source.map((item) => {
            const totalEachShop = 0;
            item.shopItem.map((items) => {
                if (items.isChecked === true) {
                    totalEachShop += items.price * items.quantity;
                }
            });
            if (item.voucher !== null) {
                totalEachShop -= Number(item.voucher.value);
            }
            if (totalEachShop <= 0) {
                totalEachShop = 0;
            }
            total += totalEachShop;
        });
        if (voucherAccept) {
            total -= voucherAccept.value;
        }
        if (total < 0) {
            total = 0;
        }
        setTotalMoney(total);
    };
    const handleBuyItem = async () => {
        const userInfo = JSON.parse(localStorage.getItem('account'));
        if (userInfo) {
            const payload = [];
            source.map((item) => {
                const isChecked = false;
                const totalPrice = 0;
                const dataShop = {};
                const listCart = [];
                dataShop.guId = '';
                dataShop.name = item.shopName;
                dataShop.shopId = item.shopId;
                dataShop.info = '';
                dataShop.description = '';
                dataShop.feedback = '';
                //check data buy
                item.shopItem.map((items) => {
                    if (items.isChecked === true) {
                        isChecked = true;
                        const itemOrder = {};
                        itemOrder.id = items.id;
                        itemOrder.productId = items.productId;
                        itemOrder.active = 1;
                        itemOrder.quantity = items.quantity;
                        itemOrder.name = items.productName;
                        itemOrder.description = items.description;
                        itemOrder.createdTime = items.createdTime;
                        itemOrder.account = '';
                        itemOrder.product = '';
                        itemOrder.price = items.price;
                        listCart.push(itemOrder);
                        totalPrice += items.price * items.quantity;
                    }
                });
                if (totalPrice <= 0) {
                    totalPrice = 0;
                }
                dataShop.price = totalPrice;
                dataShop.totalPrice = totalPrice;
                dataShop.listCart = listCart;
                //check voucher
                if (item.voucher) {
                    dataShop.voucherCode = item.voucher.code;
                    dataShop.voucher = item.voucher.name;
                    dataShop.discount = item.voucher.value;
                    dataShop.finalPrice =
                        Number(totalPrice) - Number(item.voucher.value);
                } else {
                    dataShop.voucherCode = '';
                    dataShop.voucher = '';
                    dataShop.discount = 0;
                    dataShop.finalPrice = totalPrice;
                }
                if (isChecked === true) {
                    payload.push(dataShop);
                }
            });
            setDataOrder(payload);
            setIsModalVisible(true);
        }
    };
    const currencyFormat = (num) => {
        return (
            num.toFixed(0).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,') + ' vnd'
        );
    };

    const getVoucher = async () => {
        const voucherCode = document.getElementById('input_voucher').value;
        const payload = {};
        payload.voucherCode = voucherCode;
        const result = await VoucherRepository.getVoucherByCode(payload);
        if (result) {
            if (result.quantity < 1) {
                notification['warning']({
                    message: 'Apply Voucher Fail',
                    description: 'Voucher not enough quantity',
                });
            } else {
                setVoucherAccept(result[0]);
            }
        }
    };

    useEffect(() => {
        totalPay();
    }, [source]);
    return (
        <div
            style={{
                display: 'flex',
                width: '100%',
                justifyContent: 'center',
            }}>
            <table
                style={{ width: '90%', backgroundColor: 'white' }}
                className="table  ps-table--shopping-cart ps-table--responsive">
                <thead>
                    <tr>
                        <th>Order All</th>
                        <th>Voucher</th>
                        <th>total money</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td style={{ paddingLeft: '40px' }}>
                            <input
                                type="checkbox"
                                style={{
                                    width: '20px',
                                    height: '20px',
                                }}
                                onChange={(e) => handleCheckBoxAll(e)}
                            />
                        </td>
                        {!voucherAccept ? (
                            <td style={{ display: 'flex', width: '100%',height:"82px" }}>
                                <input
                                    id="input_voucher"
                                    placeholder="Enter Voucher..."
                                    style={{
                                        borderTopLeftRadius: '30px',
                                        borderBottomLeftRadius: '30px',
                                    }}></input>
                                <input
                                    className="buttonCart"
                                    type="submit"
                                    value="Select Voucher"
                                    style={{
                                        borderTopRightRadius: '30px',
                                        borderBottomRightRadius: '30px',
                                    }}
                                    onClick={() => getVoucher()}></input>
                            </td>
                        ) : (
                            <td>
                                <span>{voucherAccept.name}</span>
                            </td>
                        )}
                        <td
                            style={{
                                textAlign: 'center',
                                width: '100%',
                            }}>
                            {currencyFormat(totalMoney)}{' '}
                        </td>
                        <td>
                            <input
                                className="buttonCart"
                                type="submit"
                                style={{
                                    padding: '10px 35px',
                                    borderRadius: '30px',
                                    border: 'none',
                                }}
                                onClick={() => handleBuyItem()}
                                value="Buy"
                            />
                        </td>
                    </tr>
                </tbody>
            </table>
            {dataOrder.length > 0 && (
                <Modal
                    visible={isModalVisible}
                    onCancel={() => setIsModalVisible(false)}
                    footer={null}>
                    <LocationForm
                        dataOrder={dataOrder}
                        totalMoney={totalMoney}
                    />
                </Modal>
            )}
        </div>
    );
};
export default CartPay;
