import React, { useEffect, useState } from 'react'
import { Finance } from '../../Types/Interface/Finance'
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
        <div className="container-xl bg-indigo-700">
            <h2 className="text-3xl font-bold text-white mb-6 ml-36">
                My Jobs:
            </h2>
            <div className="grid grid-col-1 text-center gap-6">
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