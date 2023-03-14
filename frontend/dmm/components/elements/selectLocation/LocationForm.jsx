import useLocationForm from './useLocationForm';
import Select from 'react-select';
import { useState } from 'react';
import OrderRepository from '~/repositories/OrderRepository';
import TextArea from 'antd/lib/input/TextArea';
import { notification } from 'antd';
import { useRouter } from 'next/router';
const LocationForm = ({ totalMoney = 0, dataOrder }) => {
    const Router = useRouter();
    const [number, setNumber] = useState('');
    const [description, setDescription] = useState('');
    const [paymentType, setPaymentType] = useState('momo');
    const [transport, setTransport] = useState({
        value: 'ghn',
        label: 'Giao Hàng Nhanh',
    });
    const {
        state,
        onCitySelect,
        onDistrictSelect,
        onWardSelect,
    } = useLocationForm(false);
    const {
        cityOptions,
        districtOptions,
        wardOptions,
        selectedCity,
        selectedDistrict,
        selectedWard,
    } = state;
    const currencyFormat = (num) => {
        return (
            num.toFixed(0).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,') + ' vnd'
        );
    };
    const dataTransport = [
        { value: 'ghn', label: 'Giao Hàng Nhanh' },
        { value: 'ghtk', label: 'Giao Hàng Tiết Kiệm' },
    ];
    const onSubmits = async (data) => {
        if (
            selectedCity !== null &&
            selectedDistrict !== null &&
            selectedWard !== null
        ) {
            if (number === '') {
                notification['warning']({
                    message: 'Order Failed',
                    description: 'Please enter phone number',
                });
                return null;
            }

            data.map((item) => {
                item.info =
                    selectedCity.label +
                    ',' +
                    selectedDistrict.label +
                    ',' +
                    selectedWard.label;
                item.description = description;
                if (paymentType === 'cod') {
                    item.orderTypeId = 1000002;
                } else if (paymentType === 'momo') {
                    item.orderTypeId = 1000001;
                }
                item.shippingUnit = transport.label;
                return item;
            });
            const result = await OrderRepository.orderItem(data);
            if (result) {
                if (paymentType === 'cod') {
                    const payloads = [];
                    const idOrder = result[0];
                    for (let i = 0; i < idOrder.length; i++) {
                        const dataTransaction = {};
                        dataTransaction.orderId = idOrder[i];
                        dataTransaction.name = data[i].name;
                        dataTransaction.info = data[i].info;
                        dataTransaction.receiverInfor = number;
                        payloads.push(dataTransaction);
                    }
                    const responseTransaction = await OrderRepository.addTransaction(
                        payloads
                    );
                    if (responseTransaction) {
                        notification['success']({
                            message: 'Order Success',
                        });
                        Router.push('/');
                    }
                } else if (paymentType === 'momo') {
                    const payloadMomo = {};
                    const cartCode = '';
                    const orderCode = '';
                    result[0].map((item, index) => {
                        if (index !== 0) {
                            orderCode += '_';
                        }
                        orderCode += item;
                    });
                    data.map((item, index) => {
                        item.listCart.map((items, indexs) => {
                            if (index !== 0 || indexs !== 0) {
                                cartCode += '_';
                            }
                            cartCode += items.id;
                        });
                    });
                    payloadMomo.orderId = orderCode;
                    payloadMomo.cartId = cartCode;
                    payloadMomo.amount = totalMoney;
                    payloadMomo.OrderInfor = number;
                    const resultPaymentMomo = await OrderRepository.getPaymentMomoLink(
                        payloadMomo
                    );
                    if (resultPaymentMomo) {
                        Router.push(resultPaymentMomo[0]);
                    }
                }
            }
        } else {
            notification['error']({
                message: 'Order Failed',
                description: 'Please finish your address',
            });
        }
    };
    const handleSelectNumber = (e) => {
        if (Number(e) || e == '' || e === '0') {
            setNumber(e);
        }
    };
    return (
        <div
            className="w-11/12 p-5 mx-auto mt-10 bg-gray-100 border-2 rounded md:w-2/3 sm:w-3/4 lg:w-1/2 xl:w-1/3"
            style={{
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
                justifyContent: 'space-between',
            }}>
            <div className="flex flex-col gap-5" style={{ width: '100%' }}>
                <Select
                    name="cityId"
                    key={`cityId_${selectedCity?.value}`}
                    isDisabled={cityOptions.length === 0}
                    options={cityOptions}
                    onChange={(option) => onCitySelect(option)}
                    placeholder="Tỉnh/Thành"
                    defaultValue={selectedCity}
                />

                <Select
                    name="districtId"
                    key={`districtId_${selectedDistrict?.value}`}
                    isDisabled={districtOptions.length === 0}
                    options={districtOptions}
                    onChange={(option) => onDistrictSelect(option)}
                    placeholder="Quận/Huyện"
                    defaultValue={selectedDistrict}
                />

                <Select
                    name="wardId"
                    key={`wardId_${selectedWard?.value}`}
                    isDisabled={wardOptions.length === 0}
                    options={wardOptions}
                    placeholder="Phường/Xã"
                    onChange={(option) => onWardSelect(option)}
                    defaultValue={selectedWard}
                />
                <TextArea
                    placeholder="Enter description..."
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                    style={{
                        height: '150px',
                    }}></TextArea>
                <input
                    placeholder="Enter phone number..."
                    value={number}
                    onChange={(e) => handleSelectNumber(e.target.value)}
                    style={{ padding: '8px 0', width: '100%' }}></input>
                <div
                    style={{
                        display: 'flex',
                        justifyContent: 'space-between',
                    }}>
                    <strong>Total Money:</strong>
                    <strong>{currencyFormat(totalMoney)}</strong>
                </div>
            </div>
            <div
                style={{
                    display: 'flex',
                    justifyContent: 'space-between',
                    width: '100%',
                    paddingTop: '15px',
                }}>
                <strong>Payment Type: </strong>
                <div
                    style={{
                        padding: '5px',
                        border: paymentType === 'cod' && '1px solid green',
                    }}
                    onClick={() => setPaymentType('cod')}>
                    <img
                        src="/static/img/cod.png"
                        style={{
                            width: '40px',
                        }}></img>
                </div>
                <div
                    style={{
                        padding: '5px',
                        border: paymentType === 'momo' && '1px solid green',
                    }}
                    onClick={() => setPaymentType('momo')}>
                    <img
                        src="/static/img/momo.png"
                        style={{ width: '40px' }}></img>
                </div>
            </div>
            <div
                style={{
                    display: 'flex',
                    justifyContent: 'space-between',
                    width: '100%',
                    paddingTop: '15px',
                    paddingBottom: '15px',
                }}>
                <strong>Shipping services:</strong>
                <div style={{ width: '50%' }}>
                    <Select
                        options={dataTransport}
                        onChange={(option) => setTransport(option)}
                        defaultValue={transport}
                    />
                </div>
            </div>
            <button
                type="submit"
                onClick={() => onSubmits(dataOrder)}
                style={{ padding: '5px 10px', margin: '10px 0', width: '30%' }}>
                Order
            </button>
        </div>
    );
};

export default LocationForm;
