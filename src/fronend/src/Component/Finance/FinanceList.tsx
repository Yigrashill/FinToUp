import React, { useEffect, useState } from 'react'
import { Finance } from '../../Types/Interfaces/Finance/Finance'
import { financeService } from '../../Services/FinanceService';
import FinanceItem from './FinanceItem';

const FinanceList = () => {

    const [finances, setFinances] = useState<Finance[]>([]);

    useEffect(() => {
        const fetchFinances = async () => {
            try {
                const data  = await financeService.getFinances();
                setFinances(data);
            }
            catch (error) {
                console.log(error);
            }
        }   
        fetchFinances();
    }, []);

  return (
        <div className="container-xl lg:container m-auto bg-white">
            <h2 className="text-3xl font-bold text-indigo-700 mb-6 ml-36">
                My Finances:
            </h2>
            <div className="grid grid-col-1 md:grid-cols-4 gap-6 ">
            {
                finances.map((finance : Finance ) => (
                    <FinanceItem key={finance.id} finance={finance} />
                ))
            }
            </div>
        </div>
  )
}

export default FinanceList