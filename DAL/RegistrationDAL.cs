using desktopapp_GYM.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktopapp_GYM.DAL
{
    public class RegistrationDAL : DataConnection
    {
        public decimal GetMonthlyRevenue()
        {
            string sql = @"SELECT ISNULL(SUM(TOTALAMOUNT), 0) 
                           FROM REGISTRATIONS 
                           WHERE MONTH(REGDATE) = MONTH(GETDATE()) 
                             AND YEAR(REGDATE)  = YEAR(GETDATE())";
            using (SqlConnection con = GetConnection())  // ← GetConnection() trực tiếp
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }
        public DataTable GetRevenueData()
        {
            string sql = @"
                SELECT FORMAT(REGDATE, 'MM/yyyy') AS MonthYear, 
                       SUM(TOTALAMOUNT) AS Total 
                FROM REGISTRATIONS 
                GROUP BY FORMAT(REGDATE, 'MM/yyyy'), YEAR(REGDATE), MONTH(REGDATE)
                ORDER BY YEAR(REGDATE) ASC, MONTH(REGDATE) ASC";

            DataTable dt = new DataTable();
            using (SqlConnection con = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
            }
            return dt;
        }

        public List<RegistrationDTO> GetAll()
        {
            var list = new List<RegistrationDTO>();
            string sql = @"
                SELECT r.REGID, r.MEMBERID, m.FULLNAME AS MemberName,
                       r.PACKAGEID, p.PACKAGENAME AS PackageName,
                       r.TRAINERID, t.FULLNAME AS TrainerName,
                       r.REGDATE, r.ENDDATE, m.PHONE AS MemberPhone,
                       r.TOTALAMOUNT, r.ORIGINAL_PRICE, r.DISCOUNT_AMOUNT,
                       r.PAYMENTSTATUS, p.PT_SESSIONS_PER_WEEK AS SessionsPerWeek,
                       r.SESSIONS_TOTAL, r.SESSIONS_LEFT,
                       r.IS_ACTIVE, r.NOTES, p.TYPE AS PackageType,
                       STUFF((
                           SELECT ', ' + ts.SLOTNAME
                           FROM REGISTRATION_SLOTS rs
                           JOIN TIMESLOTS ts ON rs.SLOTID = ts.SLOTID
                           WHERE rs.REGID = r.REGID
                           FOR XML PATH('')
                       ), 1, 2, '') AS SlotSummary
                FROM REGISTRATIONS r
                JOIN MEMBERS  m ON r.MEMBERID  = m.MEMBERID
                JOIN PACKAGES p ON r.PACKAGEID = p.PACKAGEID
                LEFT JOIN TRAINERS t ON r.TRAINERID = t.TRAINERID
                ORDER BY r.REGDATE DESC";

            try
            {
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) list.Add(MapReader(reader));
                }
            }
            catch (Exception ex) { throw ex; }
            return list;
        }

        public List<RegistrationDTO> GetByMember(int memberId)
        {
            var list = new List<RegistrationDTO>();
            string sql = @"
                SELECT r.REGID, r.MEMBERID, m.FULLNAME AS MemberName,
                       r.PACKAGEID, p.PACKAGENAME AS PackageName,
                       r.TRAINERID, t.FULLNAME AS TrainerName,
                       r.REGDATE, r.ENDDATE, m.PHONE AS MemberPhone,
                       r.TOTALAMOUNT, r.ORIGINAL_PRICE, r.DISCOUNT_AMOUNT,
                       r.PAYMENTSTATUS, p.PT_SESSIONS_PER_WEEK AS SessionsPerWeek,
                       r.SESSIONS_TOTAL, r.SESSIONS_LEFT,
                       r.IS_ACTIVE, r.NOTES, p.TYPE AS PackageType,
                       STUFF((
                           SELECT ', ' + ts.SLOTNAME
                           FROM REGISTRATION_SLOTS rs
                           JOIN TIMESLOTS ts ON rs.SLOTID = ts.SLOTID
                           WHERE rs.REGID = r.REGID
                           FOR XML PATH('')
                       ), 1, 2, '') AS SlotSummary
                FROM REGISTRATIONS r
                JOIN MEMBERS  m ON r.MEMBERID  = m.MEMBERID
                JOIN PACKAGES p ON r.PACKAGEID = p.PACKAGEID
                LEFT JOIN TRAINERS t ON r.TRAINERID = t.TRAINERID
                WHERE r.MEMBERID = @mid
                ORDER BY r.REGDATE DESC";

            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@mid", memberId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) list.Add(MapReader(reader));
            }
            return list;
        }

        public List<RegistrationSlotDTO> GetSlotsByReg(int regId)
        {
            var list = new List<RegistrationSlotDTO>();
            string sql = @"
                SELECT rs.ID, rs.REGID, rs.SLOTID,
                       ts.SLOTNAME, ts.DAYOFWEEK,
                       CONVERT(VARCHAR(5), ts.STARTTIME, 108) AS StartTime,
                       CONVERT(VARCHAR(5), ts.ENDTIME,   108) AS EndTime,
                       tr.FULLNAME AS TrainerName
                FROM REGISTRATION_SLOTS rs
                JOIN TIMESLOTS ts ON rs.SLOTID    = ts.SLOTID
                JOIN TRAINERS  tr ON ts.TRAINERID = tr.TRAINERID
                WHERE rs.REGID = @rid";

            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@rid", regId);
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    list.Add(new RegistrationSlotDTO
                    {
                        ID = Convert.ToInt32(r["ID"]),
                        RegID = Convert.ToInt32(r["REGID"]),
                        SlotID = Convert.ToInt32(r["SLOTID"]),
                        SlotName = r["SLOTNAME"].ToString(),
                        DayOfWeek = r["DAYOFWEEK"].ToString(),
                        StartTime = r["StartTime"].ToString(),
                        EndTime = r["EndTime"].ToString(),
                        TrainerName = r["TrainerName"].ToString()
                    });
                }
            }
            return list;
        }

        public bool Save(RegistrationDTO reg, bool isAdd)
        {
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction();
                try
                {
                    int regId;

                    if (isAdd)
                    {
                        string insertSql = @"
                            INSERT INTO REGISTRATIONS
                            (MEMBERID, PACKAGEID, TRAINERID, ENDDATE,
                             TOTALAMOUNT, ORIGINAL_PRICE, DISCOUNT_AMOUNT,
                             PAYMENTSTATUS, SESSIONS_TOTAL, SESSIONS_LEFT,
                             IS_ACTIVE, NOTES)
                            OUTPUT INSERTED.REGID
                            VALUES
                            (@mid, @pid, @tid, @end,
                             @total, @original, @discount,
                             @payment, @sessTotal, @sessLeft,
                             @active, @notes)";

                        SqlCommand cmd = new SqlCommand(insertSql, con, trans);
                        AddRegParams(cmd, reg);
                        regId = (int)cmd.ExecuteScalar();
                    }
                    else
                    {
                        string updateSql = @"
                            UPDATE REGISTRATIONS SET
                                MEMBERID        = @mid,
                                PACKAGEID       = @pid,
                                TRAINERID       = @tid,
                                ENDDATE         = @end,
                                TOTALAMOUNT     = @total,
                                ORIGINAL_PRICE  = @original,
                                DISCOUNT_AMOUNT = @discount,
                                PAYMENTSTATUS   = @payment,
                                SESSIONS_TOTAL  = @sessTotal,
                                SESSIONS_LEFT   = @sessLeft,
                                IS_ACTIVE       = @active,
                                NOTES           = @notes
                            WHERE REGID = @regid";

                        SqlCommand cmd = new SqlCommand(updateSql, con, trans);
                        cmd.Parameters.AddWithValue("@regid", reg.RegID);
                        AddRegParams(cmd, reg);
                        cmd.ExecuteNonQuery();
                        regId = reg.RegID;

                        // Xóa slots cũ để insert lại
                        SqlCommand delSlot = new SqlCommand(
                            "DELETE FROM REGISTRATION_SLOTS WHERE REGID = @rid",
                            con, trans);
                        delSlot.Parameters.AddWithValue("@rid", regId);
                        delSlot.ExecuteNonQuery();
                    }

                    // Insert slots mới
                    foreach (int slotId in reg.SelectedSlotIDs)
                    {
                        SqlCommand slotCmd = new SqlCommand(
                            "INSERT INTO REGISTRATION_SLOTS (REGID, SLOTID) VALUES (@rid, @sid)",
                            con, trans);
                        slotCmd.Parameters.AddWithValue("@rid", regId);
                        slotCmd.Parameters.AddWithValue("@sid", slotId);
                        slotCmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi lưu đăng ký: " + ex.Message);
                    return false;
                }
            }
        }

        public bool Delete(int regId)
        {
            string sql = "DELETE FROM REGISTRATIONS WHERE REGID = @id";
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", regId);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool IsSlotConflict(int memberId, int slotId, int excludeRegId = 0)
        {
            string sql = @"
                SELECT COUNT(1)
                FROM REGISTRATION_SLOTS rs
                JOIN REGISTRATIONS r ON rs.REGID = r.REGID
                WHERE r.MEMBERID  = @mid
                  AND rs.SLOTID   = @sid
                  AND r.IS_ACTIVE = 1
                  AND r.REGID    != @excl";

            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@mid", memberId);
                cmd.Parameters.AddWithValue("@sid", slotId);
                cmd.Parameters.AddWithValue("@excl", excludeRegId);
                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private RegistrationDTO MapReader(SqlDataReader r)
        {
            return new RegistrationDTO
            {
                RegID = Convert.ToInt32(r["REGID"]),
                MemberID = Convert.ToInt32(r["MEMBERID"]),
                MemberName = r["MemberName"].ToString(),
                PackageID = Convert.ToInt32(r["PACKAGEID"]),
                PackageName = r["PackageName"].ToString(),
                PackageType = r["PackageType"].ToString(),

                MemberPhone = r["MemberPhone"] == DBNull.Value ? "" : r["MemberPhone"].ToString(),
                SessionsPerWeek = r["SessionsPerWeek"] == DBNull.Value ? 0 : Convert.ToInt32(r["SessionsPerWeek"]),

                // TRAINERID nullable
                TrainerID = r["TRAINERID"] == DBNull.Value
                            ? (int?)null
                            : Convert.ToInt32(r["TRAINERID"]),
                // TrainerName từ LEFT JOIN → có thể NULL
                TrainerName = r["TrainerName"] == DBNull.Value
                            ? ""
                            : r["TrainerName"].ToString(),

                RegDate = Convert.ToDateTime(r["REGDATE"]),
                EndDate = Convert.ToDateTime(r["ENDDATE"]),
                TotalAmount = Convert.ToDecimal(r["TOTALAMOUNT"]),

                // ORIGINAL_PRICE và DISCOUNT_AMOUNT có DEFAULT 0 nhưng vẫn nên guard
                OriginalPrice = r["ORIGINAL_PRICE"] == DBNull.Value
                            ? 0
                            : Convert.ToDecimal(r["ORIGINAL_PRICE"]),
                DiscountAmount = r["DISCOUNT_AMOUNT"] == DBNull.Value
                            ? 0
                            : Convert.ToDecimal(r["DISCOUNT_AMOUNT"]),

                PaymentStatus = r["PAYMENTSTATUS"].ToString(),

                // SESSIONS_TOTAL và SESSIONS_LEFT có DEFAULT 0 nhưng vẫn guard
                SessionsTotal = r["SESSIONS_TOTAL"] == DBNull.Value
                            ? 0
                            : Convert.ToInt32(r["SESSIONS_TOTAL"]),
                SessionsLeft = r["SESSIONS_LEFT"] == DBNull.Value
                            ? 0
                            : Convert.ToInt32(r["SESSIONS_LEFT"]),

                IsActive = Convert.ToBoolean(r["IS_ACTIVE"]),

                // NOTES nullable
                Notes = r["NOTES"] == DBNull.Value
                            ? ""
                            : r["NOTES"].ToString(),

                // SlotSummary từ STUFF() → trả về NULL nếu không có slot nào
                SlotSummary = r["SlotSummary"] == DBNull.Value
                            ? ""
                            : r["SlotSummary"].ToString()
            };
        }

        private void AddRegParams(SqlCommand cmd, RegistrationDTO reg)
        {
            cmd.Parameters.AddWithValue("@mid", reg.MemberID);
            cmd.Parameters.AddWithValue("@pid", reg.PackageID);
            cmd.Parameters.AddWithValue("@tid", reg.TrainerID.HasValue
                                                         ? (object)reg.TrainerID.Value
                                                         : DBNull.Value);
            cmd.Parameters.AddWithValue("@end", reg.EndDate);
            cmd.Parameters.AddWithValue("@total", reg.TotalAmount);
            cmd.Parameters.AddWithValue("@original", reg.OriginalPrice);
            cmd.Parameters.AddWithValue("@discount", reg.DiscountAmount);
            cmd.Parameters.AddWithValue("@payment", reg.PaymentStatus ?? "Paid");
            cmd.Parameters.AddWithValue("@sessTotal", reg.SessionsTotal);
            cmd.Parameters.AddWithValue("@sessLeft", reg.SessionsLeft);
            cmd.Parameters.AddWithValue("@active", reg.IsActive);
            cmd.Parameters.AddWithValue("@notes", reg.Notes ?? (object)DBNull.Value);
        }

    }
}
