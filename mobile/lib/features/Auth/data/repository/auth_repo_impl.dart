import 'dart:developer';

import 'package:dartz/dartz.dart';
import 'package:mobile/core/error/exception.dart';
import 'package:mobile/core/network/api_constant.dart';
import 'package:mobile/core/network/api_consumer.dart';
import 'package:mobile/features/Auth/data/model/add_role_respons.dart';
import 'package:mobile/features/Auth/data/model/user_model.dart';
import 'package:mobile/features/Auth/data/repository/auth_repo.dart';

class AuthRepoImpl implements AuthRepo {
  final ApiConsumer apiConsumer;

  AuthRepoImpl({required this.apiConsumer});

  @override
  Future<Either<String, UserModel>> loginUser(
      String email, String password) async {
    try {
      final respons = await apiConsumer.post(ApiConstant.loginEndPoint,
          body: {"email": email, "password": password});
      final user = UserModel.fromJson(respons);
      return Right(user);
    } on ServerException catch (error) {
      //log(error.toString());
      String logineror = error.toString();
      log('repo error$logineror');
      return Left(logineror);
    }
  }

  @override
  Future<Either<String, String>> registerUser(
      {required String email,
      required String password,
      required String firstname,
      required String lastname,
      required String phoneNumber,
      required String userName}) async {
    try {
      final response = await apiConsumer.post(
        ApiConstant.registerEndPoint,
        body: {
          "firstName": firstname,
          "lastName": lastname,
          "phoneNumber": phoneNumber,
          "email": email,
          "userName": userName,
          "password": password
        },
      );
      return Right(response);
    } on ServerException catch (error) {
      return Left(error.toString());
    }
  }

  @override
  Future<Either<String, AddRoleRespons>> addRole(String roleName, String userName)async {
 try{
  final response=await apiConsumer.post(ApiConstant.addRoleEndPoint, body: {"roleName":roleName,"userName":userName});
  final addRoleRespons=AddRoleRespons.fromJson(response);
  return Right(addRoleRespons);
 }on ServerException catch(error){
   return Left(error.toString());
 }
  }
}
