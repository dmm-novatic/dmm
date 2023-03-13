import { notification } from 'antd';
import { useRouter } from 'next/router';
import React, { useState } from 'react';
import CartRepository from '~/repositories/CartRepository';
import VoucherRepository from '~/repositories/VoucherRepository';
import CartPay from './CartPay';
const CartTable = ({ source, getListCart }) => {
    const Router = useRouter();
    const [dataShop, setDataShop] = useState(
        Object.values(JSON.parse(JSON.stringify(source)))
    );
    const currencyFormat = (num) => {
        return (
            num.toFixed(0).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,') + ' vnd'
        );
    };
    const getVoucher = async (shopId) => {
        const voucherCode = document.getElementById(shopId + 'input').value;
        const payload = {};
        payload.shopId = shopId;
        payload.voucherCode = voucherCode;
        const result = await VoucherRepository.getVoucherByCode(payload);
        if (result && result.length > 0) {
            if (result[0].quantity < 1) {
                notification['warning']({
                    message: 'Apply Voucher Fail',
                    description: 'Voucher not enough quantity',
                });
            } else {
                const newData = dataShop.map((item) => {
                    const itemShop = item;
                    if (itemShop.shopId === shopId) {
                        itemShop.voucher = result[0];
                    }
                    return itemShop;
                });
                setDataShop(newData);
            }
        }
    };
    const updateQuantity = async (payload) => {
        const data = {};
        data.id = payload.id + '';
        data.accountId = payload.accountId + '';
        data.productId = payload.productId + '';
        data.active = payload.active + '';
        data.quantity = payload.quantity + '';
        data.name = payload.name;
        data.description = payload.description;
        data.createdTime = payload.createdTime;
        const result = await CartRepository.updateCart(data);
        if (result) {
            return true;
        }
        return false;
    };
    function totalOfShop(item, voucher) {
        const total = 0;
        item.map((items) => {
            if (items.isChecked === true) {
                total += Number(items.quantity) * Number(items.price);
            }
        });
        if (voucher !== null) {
            total -= Number(voucher.value);
        }
        if (total <= 0) {
            total = 0;
        }
        return currencyFormat(total);
    }
    function handleIncreaseItemQty(e, item, shopId) {
        e.preventDefault();
        const quantity = Number(
            document.getElementById(item.id).getAttribute('placeholder')
        );
        const newData = item;
        newData.quantity = quantity + 1;
        const newDatas = JSON.parse(JSON.stringify(dataShop));
        if (updateQuantity(newData)) {
            newDatas.map((itemShop) => {
                if (itemShop.shopId === shopId) {
                    itemShop.shopItem.map((items) => {
                        if (items.id === item.id) {
                            items = newData;
                        }
                    });
                }
            });
        }
        if (newDatas != dataShop) {
            setDataShop(newDatas);
        }
    }
    function handleOnChangeCheckBox(itemId, shopId) {
        const newData = dataShop.map((item) => {
            const newDatas = item;
            if (newDatas.shopId === shopId) {
                newDatas.shopItem = newDatas.shopItem.map((items) => {
                    const newDataItem = items;
                    if (newDataItem.id === itemId) {
                        newDataItem.isChecked = !newDataItem.isChecked;
                    }
                    return newDataItem;
                });
            }
            return newDatas;
        });
        setDataShop(newData);
    }
    function handleSelectCheckBoxShop(e, shopid) {
        const newData = dataShop.map((item) => {
            const newDatas = item;
            if (newDatas.shopId === shopid) {
                newDatas.shopItem = newDatas.shopItem.map((items) => {
                    items.isChecked = e.target.checked;
                    return items;
                });
            }
            return newDatas;
        });
        setDataShop(newData);
    }
    function handleSelectSelectAll(e) {
        const newData = dataShop.map((item) => {
            document.getElementById(item.shopId).checked = e.target.checked;
            const newDatas = item;
            newDatas.shopItem = newDatas.shopItem.map((items) => {
                items.isChecked = e.target.checked;
                return items;
            });
            return newDatas;
        });
        setDataShop(newData);
    }
    async function handleRemoveItem(e, itemId) {
        const payload = {};
        payload.id = itemId;
        const result = await CartRepository.deleteCart(payload);
        if (result) {
            getListCart();
        }
    }
    function handleDecreaseItemQty(e, item, shopId) {
        e.preventDefault();
        const quantity = Number(
            document.getElementById(item.id).getAttribute('placeholder')
        );
        if (quantity > 1) {
            const newData = item;
            newData.quantity = quantity - 1;
            const newDatas = JSON.parse(JSON.stringify(dataShop));
            if (updateQuantity(newData)) {
                newDatas.map((itemShop) => {
                    if (itemShop.shopId === shopId) {
                        itemShop.shopItem.map((items) => {
                            if (items.id === item.id) {
                                items = newData;
                            }
                        });
                    }
                });
            }
            if (newDatas != dataShop) {
                setDataShop(newDatas);
            }
        } else {
            notification['warning']({
                message: 'Update quantity failed',
                description: 'Your quantity can not decrease',
            });
        }
    }
    return (
        <div
            style={{
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
                paddingTop: '30px',
                backgroundColor: '#f5f5f5',
            }}>
            {dataShop.length !== 0 &&
                dataShop.map((item) => {
                    return (
                        <table
                            key={item.id}
                            style={{ width: '90%' }}
                            className="table  ps-table--shopping-cart ps-table--responsive">
                            <thead>
                                <tr>
                                    <th>{item.shopName}</th>
                                    <th>Item Name</th>
                                    <th>Product Image</th>
                                    <th>Quantity</th>
                                    <th>Price</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody style={{ backgroundColor: 'white' }}>
                                {item.shopItem.map((items) => {
                                    return (
                                        <tr key={items.id}>
                                            <td
                                                style={{
                                                    paddingLeft: '20px',
                                                }}>
                                                <input
                                                    type="checkbox"
                                                    checked={items.isChecked}
                                                    style={{
                                                        width: '20px',
                                                        height: '20px',
                                                    }}
                                                    onChange={() =>
                                                        handleOnChangeCheckBox(
                                                            items.id,
                                                            item.shopId
                                                        )
                                                    }
                                                />
                                            </td>
                                            <td>{items.productName}</td>
                                            <td>
                                                <img
                                                    style={{
                                                        width: '150px',
                                                        height: '100%',
                                                    }}
                                                    src={items.img}></img>
                                            </td>
                                            <td>
                                                <figure className="figure-quantity">
                                                    <div className="form-group--number">
                                                        <button
                                                            className="up"
                                                            onClick={(e) =>
                                                                handleIncreaseItemQty(
                                                                    e,
                                                                    items,
                                                                    item.shopid
                                                                )
                                                            }>
                                                            <i className="fa fa-plus"></i>
                                                        </button>
                                                        <button
                                                            className="down"
                                                            onClick={(e) =>
                                                                handleDecreaseItemQty(
                                                                    e,
                                                                    items,
                                                                    item.shopId
                                                                )
                                                            }>
                                                            <i className="fa fa-minus"></i>
                                                        </button>
                                                        <input
                                                            id={items.id}
                                                            className="form-control"
                                                            type="text"
                                                            placeholder={
                                                                items.quantity
                                                            }
                                                            disabled
                                                        />
                                                    </div>
                                                </figure>
                                            </td>
                                            <td style={{ textAlign: 'center' }}>
                                                {currencyFormat(items.price)}
                                            </td>
                                            <td>
                                                <a
                                                    onClick={(e) =>
                                                        handleRemoveItem(
                                                            e,
                                                            items.id
                                                        )
                                                    }>
                                                    <i className="icon-cross"></i>
                                                </a>
                                            </td>
                                        </tr>
                                    );
                                })}
                                <tr>
                                    <td
                                        style={{
                                            paddingLeft: '20px',
                                            display: 'flex',
                                            alignItems: 'center',
                                            width: '100%',
                                        }}>
                                        <input
                                            type="checkbox"
                                            style={{
                                                width: '20px',
                                                height: '20px',
                                            }}
                                            id={item.shopId}
                                            onChange={(e) =>
                                                handleSelectCheckBoxShop(
                                                    e,
                                                    item.shopId
                                                )
                                            }
                                        />
                                        <span style={{ paddingLeft: '10px' }}>
                                            Select All
                                        </span>
                                    </td>
                                    <td>
                                        {!item.voucher ? (
                                            <div
                                                style={{
                                                    display: 'flex',
                                                    height: '40px',
                                                }}>
                                                <input
                                                    id={item.shopId + 'input'}
                                                    placeholder="Enter Voucher..."
                                                    style={{
                                                        borderTopLeftRadius:
                                                            '30px',
                                                        borderBottomLeftRadius:
                                                            '30px',
                                                    }}></input>
                                                <input
                                                    type="submit"
                                                    value="Select Voucher"
                                                    className="buttonCart"
                                                    style={{
                                                        borderTopRightRadius:
                                                            '30px',
                                                        borderBottomRightRadius:
                                                            '30px',
                                                    }}
                                                    onClick={() =>
                                                        getVoucher(item.shopId)
                                                    }></input>
                                            </div>
                                        ) : (
                                            item.voucher.name
                                        )}
                                    </td>
                                    <td>Total Money</td>
                                    <td>
                                        {totalOfShop(
                                            item.shopItem,
                                            item.voucher
                                        )}
                                    </td>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </tbody>
                        </table>
                    );
                })}
            <CartPay
                handleCheckBoxAll={(e) => handleSelectSelectAll(e)}
                source={dataShop.length !== 0 && dataShop}></CartPay>
        </div>
    );
};
export default CartTable;
