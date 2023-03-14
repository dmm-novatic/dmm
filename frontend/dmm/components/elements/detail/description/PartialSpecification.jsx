import React from 'react';

const PartialSpecification = ({ productDetail }) => {
    return (
        <div>
            <div className="table-responsive">
                <table className="table table-bordered ps-table ps-table--specification">
                    <tbody>
                        <tr
                            hidden={
                                productDetail.color.length > 0 ? false : true
                            }>
                            <td>Color</td>
                            <td>
                                {productDetail.color.map((item, index) => {
                                    return (
                                        <span key={'item'}>
                                            {index !== 0 && ','}
                                            {item}
                                        </span>
                                    );
                                })}
                            </td>
                        </tr>
                        <tr
                            hidden={
                                productDetail.style.length > 0 ? false : true
                            }>
                            <td>Style</td>
                            <td>
                                {productDetail.style.map((item, index) => {
                                    return (
                                        <span key={'item'}>
                                            {index !== 0 && ','}
                                            {item}
                                        </span>
                                    );
                                })}
                            </td>
                        </tr>
                        <tr
                            hidden={
                                productDetail.wireless.length > 0 ? false : true
                            }>
                            <td>Wireless</td>
                            <td>
                                {productDetail.wireless.map((item, index) => {
                                    return (
                                        <span key={'item'}>
                                            {index !== 0 && ','}
                                            {item}
                                        </span>
                                    );
                                })}
                            </td>
                        </tr>
                        <tr
                            hidden={
                                productDetail.dimensions.length > 0
                                    ? false
                                    : true
                            }>
                            <td>Dimensions</td>
                            <td>
                                {productDetail.dimensions.map((item, index) => {
                                    return (
                                        <span key={'item'}>
                                            {index !== 0 && ','}
                                            {item}
                                        </span>
                                    );
                                })}
                            </td>
                        </tr>
                        <tr
                            hidden={
                                productDetail.weight.length > 0 ? false : true
                            }>
                            <td>Weight</td>
                            <td>
                                {productDetail.weight.map((item, index) => {
                                    return (
                                        <span key={'item'}>
                                            {index !== 0 && ','}
                                            {item}
                                        </span>
                                    );
                                })}
                            </td>
                        </tr>
                        <tr
                            hidden={
                                productDetail.batteryLife.length > 0
                                    ? false
                                    : true
                            }>
                            <td>Battery Life</td>
                            <td>
                                {productDetail.batteryLife.map(
                                    (item, index) => {
                                        return (
                                            <span key={'item'}>
                                                {index !== 0 && ','}
                                                {item}
                                            </span>
                                        );
                                    }
                                )}
                            </td>
                        </tr>
                        <tr
                            hidden={
                                productDetail.bluetooth.length > 0
                                    ? false
                                    : true
                            }>
                            <td>Bluetooth</td>
                            <td>
                                {productDetail.bluetooth.map((item, index) => {
                                    return (
                                        <span key={'item'}>
                                            {index !== 0 && ','}
                                            {item}
                                        </span>
                                    );
                                })}
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default PartialSpecification;
