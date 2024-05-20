import React, { useEffect, useState } from 'react'
import { Finance } from '../../Types/Interfaces/Finance/Finance'
import { financeService } from '../../Services/FinanceService';
import FinanceItem from './FinanceItem';
import { formatDate } from '../../Services/UtilityService';

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
    <div className="h-screen bg-slate-200 overflow-hidden flex items-center justify-center">
        <div className="flex min-h-screen items-center justify-center bg-white">
            <div className="p-6 overflow-scroll px-0">
                <table className="w-full min-w-max table-auto text-left">
                    <thead>
                    <tr>
                        <th className="border-y border-blue-gray-100 p-4">
                            <p className="block antialiased font-sens text-sm text-blue-gray-900 font-normal leading-none opacity-700">
                                Transaction
                            </p>
                        </th>
                        <th className="border-y border-blue-gray-100 bg-blue-gray50/50 p-4">
                            <p className="block antialiased font-sens text-sm text-blue-gray-900 font-normal leading-none opacity-700">
                                Amount
                            </p>
                        </th>
                        <th className="border-y border-blue-gray-100 bg-blue-gray50/50 p-4">
                            <p className="block antialiased font-sens text-sm text-blue-gray-900 font-normal leading-none opacity-700">
                                TYPE
                            </p>
                        </th>
                        <th className="border-y border-blue-gray-100 bg-blue-gray50/50 p-4">
                            <p className="block antialiased font-sens text-sm text-blue-gray-900 font-normal leading-none opacity-700">
                                Date
                            </p>
                        </th>
                        {/* <th className="border-y border-blue-gray-100 bg-blue-gray50/50 p-4">
                            <p className="block antialiased font-sens text-sm text-blue-gray-900 font-normal leading-none opacity-700">
                                
                            </p>
                        </th> */}
                    </tr>
                    </thead>
                    <tbody>
                            {
                                finances.map((finance : Finance) => (
                                    <FinanceItem key={finance.id} finance={finance} />
                                ))
                            }
                      
                    </tbody>
                </table>
            </div>
        </div>
        </div>

  )
}

export default FinanceList