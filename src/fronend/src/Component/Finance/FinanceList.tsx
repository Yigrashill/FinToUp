import React, { useEffect, useState } from 'react'
import { Finance } from '../../Types/Interfaces/Finance/Finance'
import { financeService } from '../../Services/FinanceService';
import FinanceItem from './FinanceItem';
import { formatDate } from '../../Services/UtilityService';

const FinanceList = () => {

    const [finances, setFinances] = useState<Finance[]>([]);
    const [items, setItems] = useState<Finance[]>([]);

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
    <div className="w-full flex flex-col-reverse items-center justify-center pb-8">
         <table className="min-w-full divide-y divide-gray-200 overflow-x-auto">
            <thead className="bg-gray-750">
                <tr>
                    <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-100 uppercase tracking-wider">
                        Title
                    </th>
                    <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-100 uppercase tracking-wider">
                        Amount
                    </th>
                    <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-100 uppercase tracking-wider">
                        Type
                    </th>
                    <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-100 uppercase tracking-wider">
                        Date
                    </th>
                </tr>
            </thead>
            <tbody className="bg-gray-800 divide-y divide-gray-800">
            {
                finances.map((finance : Finance) => (
                    <FinanceItem key={finance.id} finance={finance} />
                ))
            }
            </tbody>
            </table> 
    </div>
  )
}

export default FinanceList